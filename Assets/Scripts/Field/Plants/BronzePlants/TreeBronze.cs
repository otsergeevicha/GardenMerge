using Field.GardenObserver;
using Services.Collect;
using UnityEngine;

namespace Field.Plants.BronzePlants
{
    public class TreeBronze : Vegetation
    {
        private const float RequiredTimeForCollect = 3.5f;
        private const float RewardTimeToRipe = 5f;
        private const int Level = 4;

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