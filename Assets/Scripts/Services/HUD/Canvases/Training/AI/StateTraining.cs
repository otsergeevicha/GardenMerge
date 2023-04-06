using UnityEngine;

namespace Services.HUD.Canvases.Training.AI
{
    public abstract class StateTraining : MonoBehaviour, ISwitcherStateTraining
    {
        protected TrainingStateMachine TrainingStateMachine;
        protected TrainingScenario TrainingScenario;

        public void EnterBehavior() =>
            gameObject.SetActive(true);

        public void ExitBehavior() =>
            gameObject.SetActive(false);

        public void Init(TrainingStateMachine trainingStateMachine,
            TrainingScenario trainingScenario)
        {
            TrainingStateMachine = trainingStateMachine;
            TrainingScenario = trainingScenario;
        }
    }
}