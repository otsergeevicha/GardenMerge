using UnityEngine;

namespace Services.HUD.Canvases
{
    public class CanvasEvaluationGame : MonoBehaviour
    {
        [SerializeField] private CanvasHud _canvasHud;
        
        public void OnVisible()
        {
            _canvasHud.gameObject.SetActive(false);
            gameObject.SetActive(true);
        }

        public void OffVisible()
        {
            _canvasHud.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        public void OnEvaluation()
        {
            OffVisible();
            // логика оценки игры с применение колбека и зачисления в нем OnSuccessCallback
            print("логика оценки игры с применение колбека и зачисления в нем OnSuccessCallback");
        }

        private void OnSuccessCallback()
        {
            _canvasHud.gameObject.SetActive(true);
        }
    }
}