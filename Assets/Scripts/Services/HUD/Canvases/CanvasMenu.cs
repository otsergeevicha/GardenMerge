using CrazyGames;
using GameAnalyticsSDK;
using Infrastructure.SaveLoadLogic;
using Services.HUD.Canvases.AlmanacLogic;
using UnityEngine;

namespace Services.HUD.Canvases
{
    public class CanvasMenu : MonoBehaviour
    {
        [SerializeField] private CanvasSetting _canvasSetting;
        [SerializeField] private CanvasHud _canvasHud;
        [SerializeField] private AlmanacModule _almanacModule;
        [SerializeField] private SaveLoad _saveLoad;

        private void FixedUpdate()
        {
            if (isActiveAndEnabled == false)
                return;

            Time.timeScale = 0;
        }

        public void ContinueGame()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:TapToStart");
            


            if (_saveLoad.ReadFirstTraining())
            {
                GameAnalytics.NewDesignEvent($"ButtonClick:TapToStart:InterstitialAd:Open");
                CrazyAds.Instance.beginAdBreak(SuccessCallback, ErrorCallback);
            }

            if (_saveLoad.ReadFirstTraining() == false)
            {
                gameObject.SetActive(false);
                _canvasHud.gameObject.SetActive(true);
                Time.timeScale = 1;
            }
        }

        private void ErrorCallback()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:TapToStart:InterstitialAd:Error");
            
            gameObject.SetActive(false);
            _canvasHud.gameObject.SetActive(true);
            _almanacModule.FirstSelection();
            Time.timeScale = 1;
        }

        private void SuccessCallback()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:TapToStart:InterstitialAd:Close");
            
            gameObject.SetActive(false);
            _canvasHud.gameObject.SetActive(true);
            _almanacModule.FirstSelection();
            Time.timeScale = 1;
        }

        public void OnVisibleSettingCanvas() =>
            _canvasSetting.gameObject.SetActive(true);
    }
}