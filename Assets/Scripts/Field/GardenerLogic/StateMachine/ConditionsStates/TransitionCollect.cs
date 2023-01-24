using Field.GardenerLogic.StateMachine.States;
using UnityEngine;

namespace Field.GardenerLogic.StateMachine.ConditionsStates
{
    public class TransitionCollect : Transition
    {
        [SerializeField] private StateCollect _stateCollect;
        
        public override GardenerState GetNextState() => 
            IsCollect ? _stateCollect : null;
    }
}