namespace Services.HUD.Canvases.Training.AI.BehaviorScenario
{
    public class MergeSeed : StateTraining
    {
        private void Update()
        {
            if (isActiveAndEnabled == false)
            {
                gameObject.SetActive(false);
                return;
            }

            gameObject.SetActive(true);

            if (TrainingScenario.ReadThreeStep())
            {
                print("3");
                TrainingStateMachine.EnterBehavior<MoveSeed>();
            }
        }
    }
}