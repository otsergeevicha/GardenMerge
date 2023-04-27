using CrazyGames;
using GameAnalyticsSDK;
using Infrastructure.SaveLoadLogic;
using Services.HUD.Canvases.AlmanacLogic;
using Services.Sound;
using UnityEngine;

namespace Services.HUD.Canvases
{
    public class CanvasMenu : MonoBehaviour
    {
        [SerializeField] private CanvasSetting _canvasSetting;
        [SerializeField] private CanvasHud _canvasHud;
        [SerializeField] private AlmanacModule _almanacModule;
        [SerializeField] private SoundOperator _soundOperator;
        [SerializeField] private SaveLoad _saveLoad;

        private void Start() =>
            _soundOperator.UnMute();

        private void FixedUpdate()
        {
            if (isActiveAndEnabled == false)
                return;

            Time.timeScale = 0;
        }

        public void ContinueGame()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:TapToStart");

            if (_saveLoad.ReadFirstTraining() == false)
            {
                gameObject.SetActive(false);
                _canvasHud.gameObject.SetActive(true);
                _almanacModule.FirstSelection();
                Time.timeScale = 1;
                _soundOperator.UnMute();
            }

            if (_saveLoad.ReadFirstTraining())
            {
                GameAnalytics.NewDesignEvent($"ButtonClick:TapToStart:InterstitialAd:Open");
                _soundOperator.Mute();

                CrazyAds.Instance.beginAdBreak(CompletedCallback, ErrorCallback);
            }
        }

        public void OnVisibleSettingCanvas()
        {
            CrazyEvents.Instance.GameplayStart();
            _canvasSetting.gameObject.SetActive(true);
        }

        private void ErrorCallback()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:TapToStart:InterstitialAd:Error");

            gameObject.SetActive(false);
            _canvasHud.gameObject.SetActive(true);
            _almanacModule.FirstSelection();
            Time.timeScale = 1;
            _soundOperator.UnMute();
        }

        private void CompletedCallback()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:TapToStart:InterstitialAd:Close");

            gameObject.SetActive(false);
            _canvasHud.gameObject.SetActive(true);
            _almanacModule.FirstSelection();
            Time.timeScale = 1;
            _soundOperator.UnMute();
        }
    }
}