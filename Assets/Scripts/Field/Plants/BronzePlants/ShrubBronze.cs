using System.Collections;
using Field.GardenerLogic;
using Field.GardenObserver;
using Field.Tiles.Move;
using UnityEngine;

namespace Field.Plants.BronzePlants
{
    public class ShrubBronze : Vegetation
    {
        [SerializeField] private Leaves _leaves;
        [SerializeField] private GameObject _dustStorm;
        [SerializeField] private GameObject _leafExplosion;
        
        private const float RequiredTimeForCollect = 2.5f;
        private const float RewardTimeToRipe = 4f;
        private const int Level = 3;

        private bool _isRiped;
        private Coroutine _coroutine;

        private void Start() =>
            _isRiped = false;

        private void OnTriggerEnter(Collider collision)
        {
            if(collision.TryGetComponent(out ObserverTargets _))
                _isRiped = true;
            
            if(collision.TryGetComponent(out Gardener _)) 
                _coroutine = StartCoroutine(CollectingLeaves());
            
            if (collision.TryGetComponent(out TileMerge _))
            {
                if (_coroutine != null) 
                    StopCoroutine(_coroutine);
                
                _isRiped = false;
            }
        }

        private void OnTriggerExit(Collider collision)
        {
            if(collision.TryGetComponent(out ObserverTargets _))
                _isRiped = false;
        }

        public override bool IsRipe() =>
            _isRiped;

        public override int GetLevel() =>
            Level;

        private IEnumerator CollectingLeaves()
        {
            yield return new WaitForSeconds(RequiredTimeForCollect);
            _isRiped = false;
            _leaves.gameObject.SetActive(false);
            _dustStorm.gameObject.SetActive(true);
            _leafExplosion.gameObject.SetActive(true);

            yield return new WaitForSeconds(RewardTimeToRipe);
            _isRiped = true;
            _leaves.gameObject.SetActive(true);
            _dustStorm.gameObject.SetActive(false);
            _leafExplosion.gameObject.SetActive(false);
        }
    }
}