using UnityEngine;

namespace Services.HUD.Canvases
{
    public class CanvasKit : MonoBehaviour
    {
        [SerializeField] private CanvasHud _canvasHud;
        
        public void OnVisible()
        {
            _canvasHud.gameObject.SetActive(false);
            gameObject.SetActive(true);
        }

        public void OffVisible()
        {
            gameObject.SetActive(false);
            _canvasHud.gameObject.SetActive(true);
        }
    }
}