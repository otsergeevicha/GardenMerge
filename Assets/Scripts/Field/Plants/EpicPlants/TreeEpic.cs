using System.Collections;
using Field.GardenObserver;
using UnityEngine;

namespace Field.Plants.EpicPlants
{
    public class TreeEpic : Vegetation
    {
        private const float RequiredTimeForCollect = 5.5f;
        private const float RewardTimeToRipe = 8f;
        private const int Level = 12;

        private bool _isRiped;
        private Coroutine _coroutine;

        private void Start() =>
            _isRiped = true;

        private void OnTriggerEnter(Collider collision)
        {
            if(collision.TryGetComponent(out Gardener _)) 
                _coroutine = StartCoroutine(CollectingLeaves());
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