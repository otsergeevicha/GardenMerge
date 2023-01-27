using System.Collections;
using System.Linq;
using Field.Plants;
using Field.Tiles.Move;
using Infrastructure.Factory;
using UnityEngine;

namespace Field.Tiles.SpawnSeedLogic
{
    public class CheckingChanceSpawn : MonoBehaviour
    {
        [SerializeField] private TileMerge[] _tileMerges;
        [SerializeField] private SeedFactory _factory;

        [SerializeField] private float _requiredTimeForSendRay;
        [SerializeField] private float _requiredTimeCooldown;
        
        private const int LevelSpawn = 1;

        private Coroutine _coroutine;
        private int _currentIndex = 0;
        private Vector3 _creatingPlatform;

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

        private void OnVisibleSeed()
        {
            Vegetation newSeed = _factory.GetAllPlants()
                .FirstOrDefault(seed => 
                    seed.GetLevel() == LevelSpawn && seed.isActiveAndEnabled == false);

            if(newSeed != null)
            {
                newSeed.InitPosition(_creatingPlatform);
                newSeed.gameObject.SetActive(true);
            }
        }

        private bool SendRay()
        {
            for(var i = _currentIndex; i < _tileMerges.Length; i++)
            {
                if(!Physics.Raycast(_tileMerges[i].gameObject.transform.position, Vector3.up))
                {
                    _currentIndex++;
                    _creatingPlatform = _tileMerges[i].GetPosition();
                    return true;
                }

                if(_currentIndex >= _tileMerges.Length - 1) 
                    _currentIndex = 0;
            }

            return false;
        }

        private IEnumerator WorkingSpawn()
        {
            yield return new WaitForSeconds(_requiredTimeForSendRay);
            bool tempVar = SendRay();
            
            if(tempVar)
            {
                yield return new WaitForSeconds(_requiredTimeCooldown);
                OnVisibleSeed();
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }
}