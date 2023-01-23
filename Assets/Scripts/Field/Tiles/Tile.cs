using Field.Plants;
using Services.Move;
using UnityEngine;

namespace Field.Tiles
{
    public abstract class Tile : MonoBehaviour, IServiceLanding
    {
        private const float CorrectPositionY = 1.5f;
                
        private Vegetation _vegetation = null;
        protected bool _isFreePlace = true;

        private void OnTriggerExit(Collider collision)
        {
            if(collision.TryGetComponent<Vegetation>(out _))
            {
                _vegetation = null;
                _isFreePlace = true;
            }
        }

        public void TryGetLanding(Vegetation vegetation)
        {
            if(_isFreePlace)
            {
                Vector3 position = transform.position;
                vegetation.InitPosition(new Vector3(position.x, position.y + CorrectPositionY, position.z));
                ChangeFlagFreePlace(vegetation);
            }
        }

        private void ChangeFlagFreePlace(Vegetation vegetation)
        {
            _vegetation = vegetation;
            _isFreePlace = false;
        }
    }
}