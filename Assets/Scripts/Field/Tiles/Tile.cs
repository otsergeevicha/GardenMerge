using Field.Vegetation.Seeds;
using Services.Move;
using UnityEngine;

namespace Field.Tiles
{
    public abstract class Tile : MonoBehaviour, IServiceLanding
    {
        private const float CorrectPositionY = 1.5f;
                
        private Seed _seed = null;
        private bool _isFreePlace = true;

        private void OnTriggerExit(Collider collision)
        {
            if(collision.TryGetComponent<Seed>(out _))
            {
                _seed = null;
                _isFreePlace = true;
            }
        }

        public void TryGetLanding(Seed seed)
        {
            if(_isFreePlace)
            {
                Vector3 position = transform.position;
                seed.InitPosition(new Vector3(position.x, position.y + CorrectPositionY, position.z));
                ChangeFlagFreePlace(seed);
            }
        }

        private void ChangeFlagFreePlace(Seed seed)
        {
            _seed = seed;
            _isFreePlace = false;
        }
    }
}