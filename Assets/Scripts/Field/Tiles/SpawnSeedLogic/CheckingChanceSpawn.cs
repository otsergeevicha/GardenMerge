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
        private int _currentIndex = 0;

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
            for(var i = _currentIndex; i < _tileMerges.Length; i++)
            {
                if(!Physics.Raycast(_tileMerges[i].gameObject.transform.position, Vector3.up))
                {
                    _currentIndex++;
                    _creatingPlatform = _tileMerges[i].gameObject.transform.position;
                    return true;
                }

                if(_currentIndex >= _tileMerges.Length - 1) 
                    _currentIndex = 0;
            }

            return false;
        }

        private IEnumerator WorkingSpawn()
        {
            yield return new WaitForSeconds(RequiredTimeForSendRay);
            bool tempVar = SendRay();
            
            if(tempVar)
            {
                yield return new WaitForSeconds(RequiredTimeCooldown);
                OnAllowed?.Invoke(_creatingPlatform);
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }
}