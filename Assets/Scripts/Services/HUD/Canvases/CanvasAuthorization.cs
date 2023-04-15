using Agava.YandexGames;
using GameAnalyticsSDK;
using UnityEngine;

namespace Services.HUD.Canvases
{
    public class CanvasAuthorization : MonoBehaviour
    {
        public void OnVisible()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:CanvasAuthorization:Open");
            
            gameObject.SetActive(true);
        }

        public void LogIn()
        {
            OffVisible();
            PlayerAccount.Authorize(OnSuccessCallback, OnErrorCallback);
        }

        private void OnSuccessCallback() => 
            GameAnalytics.NewDesignEvent($"ButtonClick:CanvasAuthorization:Success");

        private void OnErrorCallback(string description) => 
            GameAnalytics.NewDesignEvent($"ButtonClick:CanvasAuthorization:Error:{description}");

        private void OffVisible() => 
            gameObject.SetActive(false);
    }
}