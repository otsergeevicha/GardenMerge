using Field.Plants;
using UnityEngine;

namespace Field.GardenerLogic.StateMachine
{
    [RequireComponent(typeof(Gardener))]
    public class CollectState : State
    {
        private const string IsCollect = "IsCollect";
        
        private int _counter = 0;
        private Vegetation _vegetation;
        private Gardener _gardener;

        private void Start() => 
            _gardener = GetComponent<Gardener>();

        private void Update()
        {
            if (isActiveAndEnabled == false)
            {
                _vegetation = null;
                return;
            }

            Animator.SetBool(IsCollect, true);

            if (_counter == 0)
            {
                _counter++;
                _vegetation.Collect();
            }

            if (_vegetation.IsRipe() == false) 
                NextState();
        }

        private void NextState()
        {
            Animator.SetBool(IsCollect, false);
            _counter = 0;
            _gardener.ApplyMoney(_vegetation.PriceCollect());
            StateMachine.EnterBehavior<SearchTargetState>();
        }

        public void InitVegetation(Vegetation vegetation) =>
            _vegetation = vegetation;
    }
}