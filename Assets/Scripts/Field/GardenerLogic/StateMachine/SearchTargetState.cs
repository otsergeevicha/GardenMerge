using Field.GardenObserver;
using Field.Plants;
using UnityEngine;

namespace Field.GardenerLogic.StateMachine
{
    [RequireComponent(typeof(OperatorTargets))]
    [RequireComponent(typeof(MovementState))]
    [RequireComponent(typeof(CollectState))]
    public class SearchTargetState : State
    {
        private OperatorTargets _targets;
        private MovementState _movementState;
        private CollectState _collectState;

        private void Start()
        {
            _targets = GetComponent<OperatorTargets>();
            
            _movementState = GetComponent<MovementState>();
            _collectState = GetComponent<CollectState>();
        }

        private void Update()
        {
            if (isActiveAndEnabled == false)
                return;

            Search();
        }

        private void Search()
        {
            Vegetation vegetation = _targets.TryGetTarget();

            if (vegetation != null)
            {
                _movementState.InitVegetation(vegetation);
                _collectState.InitVegetation(vegetation);
                StateMachine.EnterBehavior<MovementState>();
            }
        }
    }
}