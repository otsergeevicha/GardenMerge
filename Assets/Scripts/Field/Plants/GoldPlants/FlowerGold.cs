using Field.GardenObserver;
using Services.Collect;
using UnityEngine;

namespace Field.Plants.GoldPlants
{
    public class FlowerGold : Vegetation
    {
        private const float RequiredTimeForCollect = .75f;
        private const float RewardTimeToRipe = 2.5f;
        private const int Level = 6;

        private bool _isRiped;
        private Coroutine _coroutine;

        private void Start() =>
            _isRiped = true;

        private void OnTriggerEnter(Collider collision)
        {
            if(collision.TryGetComponent(out Gardener _))
                CollectingLeaves();
        }

        private void CollectingLeaves()
        {
            _coroutine = StartCoroutine(IServiceCollect.WorkWithPlants(RequiredTimeForCollect));

            if(_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(IServiceCollect.WorkWithPlants(RewardTimeToRipe));
            
            if(_coroutine != null)
                StopCoroutine(_coroutine);

            _isRiped = true;
        }

        public override bool IsRipe() =>
            _isRiped;

        public override int GetLevel() =>
            Level;
    }
}