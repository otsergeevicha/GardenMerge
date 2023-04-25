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

            gameObject.SetActive(false);
            _canvasHud.gameObject.SetActive(true);
            _almanacModule.FirstSelection();
            Time.timeScale = 1;
            _soundOperator.UnMute();
        }

        public void OnVisibleSettingCanvas() =>
            _canvasSetting.gameObject.SetActive(true);
    }
}