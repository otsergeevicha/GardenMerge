using Infrastructure.SaveLoadLogic;
using UnityEngine;

namespace Services.HUD.Canvases.Training.AI
{
    public abstract class StateTraining : MonoBehaviour, ISwitcherStateTraining
    {
        protected TrainingStateMachine TrainingStateMachine;
        protected SaveLoad SaveLoad;
        protected TrainingScenario TrainingScenario;

        public void EnterBehavior() =>
            enabled = true;

        public void ExitBehavior() =>
            enabled = false;

        public void Init(TrainingStateMachine trainingStateMachine, SaveLoad saveLoad,
            TrainingScenario trainingScenario)
        {
            SaveLoad = saveLoad;
            TrainingStateMachine = trainingStateMachine;
            TrainingScenario = trainingScenario;
        }
    }
}