using System.Collections;
using Field.GardenObserver;
using Field.Tiles.Move;
using UnityEngine;

namespace Field.Plants.EpicPlants
{
    public class ShrubEpic : Vegetation
    {
        [SerializeField] private Leaves _leaves;
        
        [SerializeField] private GameObject _dustStorm;
        [SerializeField] private GameObject _leafExplosion;
        [SerializeField] private ParticleSystem _mergeParticle;
        [SerializeField] private ParticleSystem _fxCoins;
        
        private const float RequiredTimeForCollect = 1.7f;
        private const float RewardTimeToRipe = 6f;
        private const int Level = 11;
        private const int Price = 24;

        private bool _isRiped;
        private Coroutine _coroutine;
        private Transform _ourTransformRotation;
        private bool _isFirstMerge;

        private void Start()
        {
            _ourTransformRotation = transform;
            _isRiped = false;
            _mergeParticle.Stop();
            _fxCoins.Stop();
        }

        private void Update()
        {
            if (isActiveAndEnabled == false)
            {
                _isFirstMerge = false;
                return;
            }

            if (_isFirstMerge == false)
            {
                _mergeParticle.Play();
                _isFirstMerge = true;
            }
            
            if (_ourTransformRotation.rotation.x != 0 || _ourTransformRotation.rotation.y != 0 || _ourTransformRotation.rotation.z != 0)
                transform.rotation = Quaternion.Euler(0, 0, 0);
        }

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
                                
                _leafExplosion.gameObject.SetActive(false);
                _dustStorm.gameObject.SetActive(false);
            }
        }

        private void OnDisable() => 
            OffCoroutine();

        private void OffCoroutine()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        public override float GetTimeCollect() => 
            RequiredTimeForCollect;

        public override float GetFloweringPeriod() => 
            RewardTimeToRipe;
        
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
            _fxCoins.Play();

            yield return new WaitForSeconds(RewardTimeToRipe);
            _isRiped = true;
            _leaves.gameObject.SetActive(true);
            _dustStorm.gameObject.SetActive(false);
        }
    }
}