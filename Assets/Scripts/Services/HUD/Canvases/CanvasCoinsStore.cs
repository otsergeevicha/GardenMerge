using UnityEngine;

namespace Services.HUD.Canvases
{
    public class CanvasCoinsStore : MonoBehaviour
    {
        [SerializeField] private CanvasKit _canvasKit;
        
        public void OnVisible()
        {
            _canvasKit.OffVisible();
            gameObject.SetActive(true);
        }

        public void OffVisible() => 
            gameObject.SetActive(false);
    }
}