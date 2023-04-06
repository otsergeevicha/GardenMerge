namespace Services.HUD.Canvases.Training.AI.BehaviorScenario
{
    public class SecondBuySeed : StateTraining
    {
        private void Update()
        {
            if (isActiveAndEnabled == false)
            {
                gameObject.SetActive(false);
                return;
            }

            gameObject.SetActive(true);

            if (TrainingScenario.ReadTwoStep())
            {
                print("2");
                TrainingStateMachine.EnterBehavior<MergeSeed>();
            }
        }
    }
}