using CrazyGames;
using GameAnalyticsSDK;
using UnityEngine;

namespace Services.HUD.Canvases
{
    public class CanvasPause : MonoBehaviour
    {
        [SerializeField] private CanvasSetting _canvasSetting;
        [SerializeField] private CanvasHud _canvasHud;
        [SerializeField] private CanvasMenu _canvasMenu;

        public void OnVisibleCanvasSetting()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:Pause:SettingWindow");
            _canvasHud.gameObject.SetActive(false);
            _canvasSetting.gameObject.SetActive(true);
        }
        
        public void Visible(bool status)
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:Pause");
            _canvasHud.gameObject.SetActive(true);
            gameObject.SetActive(status);
        }

        public void OnMenu()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:Pause:OpenMenu");
            CrazyEvents.Instance.GameplayStop();
            _canvasMenu.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}