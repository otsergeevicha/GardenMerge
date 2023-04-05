namespace Services.HUD.Canvases.Training.AI.BehaviorScenario
{
    public class FirstBuySeed : StateTraining
    {
        private void Update()
        {
            if (isActiveAndEnabled == false)
            {
                gameObject.SetActive(false);
                return;
            }

            gameObject.SetActive(true);

            if (TrainingScenario.ReadOneStep()) 
                TrainingStateMachine.EnterBehavior<SecondBuySeed>();
        }
    }
}