using Field.Plants;
using Field.Tiles;
using Infrastructure.Factory;
using UnityEngine;

namespace Services.Move
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Vegetation))]
    public class DraggingOptionVegetation : MonoBehaviour, IServiceDragAndDrop
    {
        [SerializeField] private float _groundOffset;

        private PlantsFactory _plantsFactory = new OperatorFactory();
        private Rigidbody _rigidbody;
        private Vegetation _vegetation;

        private void Start()
        {
            _vegetation = GetComponent<Vegetation>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Up()
        {
            _vegetation.RecordFirstPosition(transform.position);
            SetGravity(false);
        }

        public void Drag(Vector3 newPosition) => 
            _rigidbody.position = GetWithOffset(newPosition);

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
                if(hit.collider.gameObject.TryGetComponent(out Vegetation vegetationCollision))
                    Merge(vegetationCollision);
        }

        private void Merge(Vegetation vegetationCollision)
        {
            if(vegetationCollision.GetLevel() == _vegetation.GetLevel())
            {
                Vector3 placeMerge = vegetationCollision.transform.position;
                int levelMerge = vegetationCollision.GetLevel();
                levelMerge++;
                vegetationCollision.gameObject.SetActive(false);
                _vegetation.gameObject.SetActive(false);

                foreach(Vegetation plant in _plantsFactory.GetAllPlants())
                {
                    if(plant.GetLevel() == levelMerge && plant.gameObject.activeInHierarchy == false)
                    {
                        print(levelMerge);
                        plant.gameObject.transform.position = placeMerge;
                        plant.gameObject.SetActive(true);
                        return;
                    }
                }
            }
        }

        private void Landing()
        {
            Ray ray = SendRay();

            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                if(hit.collider.gameObject.TryGetComponent(out TileLanding tileLanding))
                    tileLanding.TryGetLanding(_vegetation);

                else if(hit.collider.gameObject.TryGetComponent(out TileMerge tileMerge))
                    tileMerge.TryGetLanding(_vegetation);

                else if(hit.collider.gameObject.TryGetComponent(out Vegetation _))
                    _vegetation.InitPosition(_vegetation.ReadFirstPosition());

                else
                    _vegetation.InitPosition(_vegetation.ReadFirstPosition());
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