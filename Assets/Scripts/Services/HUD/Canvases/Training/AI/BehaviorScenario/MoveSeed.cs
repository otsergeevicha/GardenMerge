namespace Services.HUD.Canvases.Training.AI.BehaviorScenario
{
    public class MoveSeed : StateTraining
    {
        private void Update()
        {
            if (isActiveAndEnabled == false)
            {
                gameObject.SetActive(false);
                return;
            }

            gameObject.SetActive(true);

            if (TrainingScenario.ReadFourStep())
            {
                print("4");
                TrainingScenario.OnVisibleCanvasTutorial();
                gameObject.SetActive(false);
            }
        }
    }
}