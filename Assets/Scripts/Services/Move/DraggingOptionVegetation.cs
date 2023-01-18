using System;
using Field.Tiles;
using Field.Vegetation.Seeds;
using UnityEngine;

namespace Services.Move
{
    [RequireComponent(typeof(Rigidbody))]
    public class DraggingOptionVegetation : MonoBehaviour, IServiceDragAndDrop
    {
        [SerializeField] private float _groundOffset;
        [SerializeField] private Seed _seed;

        private Rigidbody _rigidbody;
        private Coroutine _coroutine;

        private void Start() =>
            _rigidbody = GetComponent<Rigidbody>();

        public void Up()
        {
            _seed.RecordFirstPosition(transform.position);
            SetGravity(false);
        }

        public void Drag(Vector3 newPosition)
        {

            _rigidbody.position = GetWithOffset(newPosition);
        }

        public void Drop()
        {
            CheckingMerge();

            Landing();
            SetGravity(true);
        }

        private void CheckingMerge()
        {
            Ray ray = SendRay();

            if(Physics.Raycast(ray, out RaycastHit hit))
                if(hit.collider.gameObject.TryGetComponent(out Seed seedCollision))
                    Merge(seedCollision);
        }

        private void Merge(Seed seedCollision)
        {
            if(seedCollision.GetLevel() != _seed.GetLevel())
            {
                Vector3 placeMerge = seedCollision.transform.position;
                int levelMerge = seedCollision.GetLevel();
                seedCollision.gameObject.SetActive(false);
                _seed.gameObject.SetActive(false);

                //Instantiate(); - здесь появляется третья сущность в зависимости от левела слитых сущностей
                print("Сущности слились " + placeMerge +
                      " позиция для спавна нового готова");
            }
        }

        private void Landing()
        {
            Ray ray = SendRay();

            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                if(hit.collider.gameObject.TryGetComponent(out TileLanding tileLanding))
                    tileLanding.TryGetLanding(_seed);

                else if(hit.collider.gameObject.TryGetComponent(out TileMerge tileMerge))
                    tileMerge.TryGetLanding(_seed);

                else if(hit.collider.gameObject.TryGetComponent(out Seed _))
                    _seed.InitPosition(_seed.ReadFirstPosition());

                else
                    _seed.InitPosition(_seed.ReadFirstPosition());
            }
        }

        private Ray SendRay() => 
            new Ray(transform.position, Vector3.down);

        private void SetGravity(bool isEnabled) =>
            _rigidbody.useGravity = isEnabled;

        private Vector3 GetWithOffset(Vector3 newPosition)
        {
            float height = _rigidbody.position.y;
            return new Vector3(newPosition.x, Mathf.MoveTowards(height, _groundOffset, 0.1f), newPosition.z);
        }
    }
}