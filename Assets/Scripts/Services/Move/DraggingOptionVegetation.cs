using Field.Plants;
using Field.Tiles;
using Field.Tiles.Move;
using Services.Merge;
using UnityEngine;

namespace Services.Move
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Vegetation))]
    public class DraggingOptionVegetation : MonoBehaviour, IServiceDragAndDrop
    {
        [SerializeField] private float _groundOffset;

        private Rigidbody _rigidbody;
        private Vegetation _vegetation;

        private Merging _merging;
        private TileMerge _tileMerge;

        private void Start()
        {
            _vegetation = GetComponent<Vegetation>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Init(Merging merging) => 
            _merging = merging;

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

        private void CheckingMerge()
        {
            RaycastHit[] arrayHits = Physics.RaycastAll(transform.position, Vector3.down, 50f);
            
            Vegetation currentVegetation = null;
            
            bool tileMerge = false;
            bool mergeVegetation = false;
            
            for(int i = 0; i < arrayHits.Length; i++)
            {
                if(arrayHits[i].collider.gameObject.TryGetComponent(out Vegetation vegetationCollision))
                {
                    currentVegetation = vegetationCollision;
                    mergeVegetation = true;
                }

                if(arrayHits[i].collider.gameObject.TryGetComponent(out TileMerge _)) 
                    tileMerge = true;
            }

            if(tileMerge && mergeVegetation) 
                _merging.Merge(currentVegetation, _vegetation);

        }

        private Ray SendRay() =>
            new(transform.position, Vector3.down);

        private void SetGravity(bool isEnabled) =>
            _rigidbody.useGravity = isEnabled;

        private Vector3 GetWithOffset(Vector3 newPosition)
        {
            float height = _rigidbody.position.y;
            return new Vector3(newPosition.x, Mathf.MoveTowards(height, _groundOffset, 0.1f), newPosition.z);
        }
    }
}