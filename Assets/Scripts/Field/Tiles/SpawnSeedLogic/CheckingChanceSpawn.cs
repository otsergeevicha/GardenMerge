using System;
using System.Collections;
using Field.Tiles.Move;
using UnityEngine;

namespace Field.Tiles.SpawnSeedLogic
{
    public class CheckingChanceSpawn : MonoBehaviour
    {
        [SerializeField] private TileMerge[] _tileMerges;

        private const float RequiredTimeForSendRay = 1f;
        private const float RequiredTimeCooldown = 5f;

        private Coroutine _coroutine;
        private Vector3 _creatingPlatform;

        public event Action<Vector3> OnAllowed;

        private void Start() =>
            _coroutine = StartCoroutine(WorkingSpawn());

        private void Update()
        {
            if(_coroutine != null)
                return;
            
            _coroutine = StartCoroutine(WorkingSpawn());
        }

        private void OnDisable()
        {
            if(_coroutine != null)
                StopCoroutine(_coroutine);
        }

        private bool SendRay()
        {
            foreach(var tile in _tileMerges)
            {
                if(!Physics.Raycast(tile.gameObject.transform.position, Vector3.up))
                {
                    _creatingPlatform = tile.gameObject.transform.position;
                    return true;
                }
            }

            return false;
        }

        private IEnumerator WorkingSpawn()
        {
            yield return new WaitForSeconds(RequiredTimeForSendRay);
            SendRay();
            
            if(SendRay())
            {
                yield return new WaitForSeconds(RequiredTimeCooldown);
                OnAllowed?.Invoke(_creatingPlatform);
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }
}