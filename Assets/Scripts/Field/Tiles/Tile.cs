using System;
using Field.Plants;
using Infrastructure.SaveLoadLogic;
using Services.Move;
using UnityEngine;

namespace Field.Tiles
{
    public abstract class Tile : MonoBehaviour, IServiceLanding
    {
        private const float CorrectPositionY = 1.5f;
                
        private Vegetation _vegetation = null;
        private bool _isFreePlace = true;

        private void OnTriggerExit(Collider collision)
        {
            if(collision.TryGetComponent(out Vegetation _))
            {
                _vegetation = null;
                _isFreePlace = true;
            }
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.TryGetComponent(out Vegetation _)) 
                _isFreePlace = false;
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

        public bool CheckStatusPlace() =>
            _isFreePlace;

        private void ChangeFlagFreePlace(Vegetation vegetation)
        {
            _vegetation = vegetation;
            _isFreePlace = false;
        }
    }
}