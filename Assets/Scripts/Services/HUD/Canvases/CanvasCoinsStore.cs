using UnityEngine;

namespace Services.HUD.Canvases
{
    public class CanvasCoinsStore : MonoBehaviour
    {
        [SerializeField] private CanvasKit _canvasKit;
        [SerializeField] private CanvasHud _canvasHud;
        
        public void OnVisible()
        {
            _canvasKit.OffVisible();
            _canvasHud.gameObject.SetActive(false);
            Time.timeScale = 0;
            gameObject.SetActive(true);
        }

        public void OffVisible()
        {
            _canvasHud.gameObject.SetActive(true);
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
    }
}