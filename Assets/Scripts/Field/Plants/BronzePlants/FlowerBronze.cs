using System;
using System.Collections;
using Field.GardenerLogic;
using Field.GardenObserver;
using UnityEngine;

namespace Field.Plants.BronzePlants
{
    public class FlowerBronze : Vegetation
    {
        private const float RequiredTimeForCollect = 1.5f;
        private const float RewardTimeToRipe = 3f;
        private const int Level = 2;

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
        }

        private void OnTriggerExit(Collider collision)
        {
            if(collision.TryGetComponent(out ObserverTargets _))
                _isRiped = false;
        }

        private IEnumerator CollectingLeaves()
        {
            yield return new WaitForSeconds(RequiredTimeForCollect);
            _isRiped = false;

            yield return new WaitForSeconds(RewardTimeToRipe);
            _isRiped = true;
        }

        public override bool IsRipe() =>
            _isRiped;

        public override int GetLevel() =>
            Level;
    }
}