using Field.GardenerLogic.StateMachine.States;
using Field.GardenObserver;
using UnityEngine;

namespace Field.GardenerLogic.StateMachine.ConditionsStates
{
    public class TransitionWalk : Transition
    {
        [SerializeField] private OperatorTargets _operator;
        [SerializeField] private StateWalk _stateWalk;

        public override GardenerState GetNextState() =>
            _operator.IsHavePath && IsCollect == false ? _stateWalk : null;
    }
}