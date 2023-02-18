using System;
using System.Collections.Generic;
using Infrastructure.SaveLoadLogic;
using Services.StateMachine;
using UnityEngine;

namespace Field.GardenerLogic.StateMachine
{
    [RequireComponent(typeof(SearchTargetState))]
    [RequireComponent(typeof(MovementState))]
    [RequireComponent(typeof(CollectState))]
    public class StateMachineGardener : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private SaveLoad _saveLoad;

        private Dictionary<Type, ISwitcherState> _allBehaviors;
        private ISwitcherState _currentBehavior;

        private void Start()
        {
            _allBehaviors = new Dictionary<Type, ISwitcherState>
            {
                [typeof(SearchTargetState)] = GetComponent<SearchTargetState>(),
                [typeof(MovementState)] = GetComponent<MovementState>(),
                [typeof(CollectState)] = GetComponent<CollectState>(),
            };

            foreach (var behavior in _allBehaviors)
            {
                behavior.Value.Init(this, _animator, _saveLoad);
                behavior.Value.ExitBehavior();
            }

            _currentBehavior = _allBehaviors[typeof(SearchTargetState)];
            EnterBehavior<SearchTargetState>();
        }

        public void EnterBehavior<TState>() where TState : ISwitcherState
        {
            var behavior = _allBehaviors[typeof(TState)];
            _currentBehavior.ExitBehavior();
            behavior.EnterBehavior();
            _currentBehavior = behavior;
        }
    }
}