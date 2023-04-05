using Infrastructure.SaveLoadLogic;
using Services.HUD.Canvases.Training.AI;

namespace Services.HUD.Canvases.Training
{
    public interface ISwitcherStateTraining
    {
        public void EnterBehavior();
        public void ExitBehavior();
        public void Init(TrainingStateMachine trainingStateMachineWarriors, SaveLoad saveLoad,
            TrainingScenario trainingScenario);
    }
}