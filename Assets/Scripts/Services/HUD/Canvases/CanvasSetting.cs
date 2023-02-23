using UnityEngine;

namespace Services.HUD.Canvases
{
    public class CanvasSetting : MonoBehaviour
    {
        [SerializeField] private CanvasHud _canvasHud;

        public void OffVisible()
        {
            _canvasHud.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}