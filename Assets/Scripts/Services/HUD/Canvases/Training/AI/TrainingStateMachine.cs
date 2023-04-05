using System;
using System.Collections.Generic;
using Infrastructure.SaveLoadLogic;
using Services.HUD.Canvases.Training.AI.BehaviorScenario;
using UnityEngine;

namespace Services.HUD.Canvases.Training.AI
{
    public class TrainingStateMachine : MonoBehaviour
    {
        [SerializeField] private TrainingScenario _trainingScenario;
        [SerializeField] private FirstBuySeed _firstBuySeed;
        [SerializeField] private SecondBuySeed _secondBuySeed;
        [SerializeField] private MergeSeed _mergeSeed;
        [SerializeField] private MoveSeed _moveSeed;

        private Dictionary<Type, ISwitcherStateTraining> _allBehaviors;
        private ISwitcherStateTraining _currentBehavior;

        private SaveLoad _saveLoad;

        private void Start()
        {
            _allBehaviors = new Dictionary<Type, ISwitcherStateTraining>
            {
                [typeof(FirstBuySeed)] = _firstBuySeed,
                [typeof(SecondBuySeed)] = _secondBuySeed,
                [typeof(MergeSeed)] = _mergeSeed,
                [typeof(MoveSeed)] = _moveSeed
            };

            foreach (var behavior in _allBehaviors)
            {
                behavior.Value.Init(this, _saveLoad, _trainingScenario);
                behavior.Value.ExitBehavior();
            }

            _currentBehavior = _allBehaviors[typeof(FirstBuySeed)];
            EnterBehavior<FirstBuySeed>();
        }

        public void Init(SaveLoad saveLoad, TrainingScenario trainingScenario)
        {
            _trainingScenario = trainingScenario;
            _saveLoad = saveLoad;
        }

        public void EnterBehavior<TState>() where TState : ISwitcherStateTraining
        {
            var behavior = _allBehaviors[typeof(TState)];
            _currentBehavior.ExitBehavior();
            behavior.EnterBehavior();
            _currentBehavior = behavior;
        }
    }
}