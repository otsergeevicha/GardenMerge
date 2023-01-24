using System.Collections.Generic;
using System.Linq;
using Field.GardenerLogic.StateMachine.ConditionsStates;
using Field.GardenerLogic.StateMachine.States;
using UnityEngine;

namespace Field.GardenerLogic.StateMachine
{
    public class ModuleStateMachineGardener : MonoBehaviour
    {
        [SerializeField] private List<GardenerState> _states;
        [SerializeField] private List<Transition> _transitions;

        [SerializeField] private GardenerState _stateSwitch;
        [SerializeField] private StateIdle _idle;
        
        private GardenerState _currentState;

        private void Start() => 
            _currentState = _idle;

        private void Update()
        {
            TryGetCurrentState();
            Transit();
        }

        private void Transit()
        {
            if (_currentState == TryGetCurrentState() || _currentState == null)
                return;

            _stateSwitch.Exit(_currentState);
            _currentState = TryGetCurrentState();
            _stateSwitch.Enter(_currentState);
    }

        private GardenerState TryGetCurrentState()
        {
            var transition = _transitions
                .FirstOrDefault(transition =>
                    transition.GetNextState() != null);
            return transition?.GetNextState();
        }
    }
}