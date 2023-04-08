using Field.Plants;
using Services.HUD;
using Services.Sound;
using UnityEngine;

namespace Field.GardenerLogic.StateMachine
{
    [RequireComponent(typeof(Gardener))]
    public class CollectState : State
    {
        [SerializeField] private FXOperator _fxOperator;
        [SerializeField] private IconEnlarger _iconEnlarger;

        private const string IsCollect = "IsCollect";

        private int _counter = 0;
        private Vegetation _vegetation;

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
                _fxOperator.PlaySoundCollect();
                _vegetation.Collect();
            }

            if (_vegetation.IsRipe() == false)
                NextState();
        }

        private void NextState()
        {
            Animator.SetBool(IsCollect, false);
            _counter = 0;
            SaveLoad.ApplyMoney(_vegetation.PriceCollect());
            _iconEnlarger.EnlargeIcon();
            _fxOperator.PlaySoundCoins();
            StateMachine.EnterBehavior<SearchTargetState>();
        }

        public void InitVegetation(Vegetation vegetation) =>
            _vegetation = vegetation;
    }
}