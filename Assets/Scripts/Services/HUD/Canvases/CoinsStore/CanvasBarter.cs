using GameAnalyticsSDK;
using UnityEngine;

namespace Services.HUD.Canvases.CoinsStore
{
    public class CanvasBarter : MonoBehaviour
    {
        public void OnVisible()
        {
            GameAnalytics.NewDesignEvent($"CanvasBarter:Open");

            Time.timeScale = 0;
            gameObject.SetActive(true);
        }

        public void OffVisible()
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
    }
}