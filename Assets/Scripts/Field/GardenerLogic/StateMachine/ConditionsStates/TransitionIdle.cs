using Field.GardenerLogic.StateMachine.States;
using Field.GardenObserver;
using UnityEngine;

namespace Field.GardenerLogic.StateMachine.ConditionsStates
{
    public class TransitionIdle : Transition
    {
        [SerializeField] private OperatorTargets _operator;
        [SerializeField] private StateIdle _stateIdle;

        public override GardenerState GetNextState() => 
            _operator.IsHavePath && IsCollect ? null : _stateIdle;
    }
}