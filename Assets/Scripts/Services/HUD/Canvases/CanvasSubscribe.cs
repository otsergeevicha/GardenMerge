using CrazyGames;
using GameAnalyticsSDK;
using Infrastructure.SaveLoadLogic;
using Services.HUD.Buttons;
using Services.Sound;
using UnityEngine;

namespace Services.HUD.Canvases
{
    public class CanvasSubscribe : MonoBehaviour
    {
        [SerializeField] private SaveLoad _saveLoad;
        [SerializeField] private ButtonSubscribe _subscribe;

        [SerializeField] private SoundOperator _soundOperator;
        [SerializeField] private CustomTimer _customTimer;

        public void See()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:ButtonSubscribe:VideoSub:Open");
            
            Time.timeScale = 0;
            _soundOperator.Mute();
            
            CrazyAds.Instance.beginAdBreakRewarded(SuccessCallback, ErrorCallback);
        }

        private void ErrorCallback()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:ButtonSubscribe:VideoSub:Error");
            UnLockGame();
        }

        private void SuccessCallback()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:ButtonSubscribe:VideoSub:Reward");
            
            _customTimer.Status = true;
            _saveLoad.ChangeStatusSubscribe(true);
            _saveLoad.ChangeStatusTempSubscribe(true);

            _subscribe.OffVisibleCanvas();
            Time.timeScale = 1;
            _soundOperator.UnMute();
        }

        private void UnLockGame()
        {
            _subscribe.OffVisibleCanvas();
            _customTimer.Status = false;
            Time.timeScale = 1;
            _soundOperator.UnMute();
        }
    }
}