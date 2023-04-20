using GameAnalyticsSDK;
using UnityEngine;

namespace Services.HUD.Canvases.CoinsStore
{
    public class CanvasBarter : MonoBehaviour
    {
        [SerializeField] private CanvasHud _canvasHud;
        
        public void OnVisible()
        {
            GameAnalytics.NewDesignEvent($"CanvasBarter:Open");

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