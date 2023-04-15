using Agava.YandexGames;
using GameAnalyticsSDK;
using Services.HUD.Canvases.AlmanacLogic;
using UnityEngine;

namespace Services.HUD.Canvases
{
    public class CanvasMenu : MonoBehaviour
    {
        [SerializeField] private CanvasSetting _canvasSetting;
        [SerializeField] private CanvasHud _canvasHud;
        [SerializeField] private AlmanacModule _almanacModule;

        private void FixedUpdate()
        {
            if (isActiveAndEnabled == false)
                return;

            Time.timeScale = 0;
        }

        public void ContinueGame()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:TapToStart");
            InterstitialAd.Show(OnOpenCallback, OnCloseCallback, OnErrorCallback);
        }

        public void OnVisibleSettingCanvas() =>
            _canvasSetting.gameObject.SetActive(true);

        private void OnErrorCallback(string description)
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:TapToStart:InterstitialAd:Error:{description}");
            
            gameObject.SetActive(false);
            _canvasHud.gameObject.SetActive(true);
            _almanacModule.FirstSelection();
            Time.timeScale = 1;
        }

        private void OnCloseCallback(bool obj)
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:TapToStart:InterstitialAd:Close");
            
            gameObject.SetActive(false);
            _canvasHud.gameObject.SetActive(true);
            _almanacModule.FirstSelection();
            Time.timeScale = 1;
        }

        private void OnOpenCallback() => 
            GameAnalytics.NewDesignEvent($"ButtonClick:TapToStart:InterstitialAd:Open");
    }
}