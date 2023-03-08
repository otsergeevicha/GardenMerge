using System.Collections;
using Field.GardenObserver;
using Field.Tiles.Move;
using UnityEngine;

namespace Field.Plants.GoldPlants
{
    public class ShrubGold : Vegetation
    {
        [SerializeField] private Leaves _leaves;
        
        [SerializeField] private GameObject _dustStorm;
        [SerializeField] private GameObject _leafExplosion;
        [SerializeField] private ParticleSystem _mergeParticle;
        
        private const float RequiredTimeForCollect = 1.5f;
        private const float RewardTimeToRipe = 3f;
        private const int Level = 7;
        private const int Price = 6;

        private bool _isRiped;
        private Coroutine _coroutine;

        private void Start() =>
            _isRiped = false;

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.TryGetComponent(out ObserverTargets _))
            {
                _leaves.gameObject.SetActive(true);
                _isRiped = true;
            }

            if (collision.TryGetComponent(out TileMerge _))
            {
                OffCoroutine();

                _isRiped = false;
            }
        }

        private void OnTriggerExit(Collider collision)
        {
            if (collision.TryGetComponent(out ObserverTargets _))
            {
                OffCoroutine();
                _leaves.gameObject.SetActive(true);
                _isRiped = false;
            }
        }

        private void OnDisable() => 
            OffCoroutine();

        public override void PlayParticleMerge() => 
            _mergeParticle.Play();
        
        private void OffCoroutine()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        public override void Collect() => 
            _coroutine = StartCoroutine(CollectingLeaves());

        public override int PriceCollect() => 
            Price;

        public override bool IsRipe() =>
            _isRiped;

        public override int GetLevel() =>
            Level;
        
        private IEnumerator CollectingLeaves()
        {
            _leafExplosion.gameObject.SetActive(true);
            yield return new WaitForSeconds(RequiredTimeForCollect);
            
            _isRiped = false;
            _leaves.gameObject.SetActive(false);
            _dustStorm.gameObject.SetActive(true);
            _leafExplosion.gameObject.SetActive(false);

            yield return new WaitForSeconds(RewardTimeToRipe);
            _isRiped = true;
            _leaves.gameObject.SetActive(true);
            _dustStorm.gameObject.SetActive(false);
        }
    }
}