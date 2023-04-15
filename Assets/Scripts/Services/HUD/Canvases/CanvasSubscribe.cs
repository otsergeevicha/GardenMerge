using Agava.YandexGames;
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

        public void See() =>
            VideoAd.Show(OnOpenCallback, OnRewardedCallback, OnCloseCallback, OnErrorCallback);

        private void OnOpenCallback()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:ButtonSubscribe:VideoSub:Open");
            
            Time.timeScale = 0;
            _soundOperator.Mute();
        }

        private void OnRewardedCallback()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:ButtonSubscribe:VideoSub:Reward");
            
            _customTimer.Status = true;
            _saveLoad.ChangeStatusSubscribe(true);
            _saveLoad.ChangeStatusTempSubscribe(true);

            _subscribe.OffVisibleCanvas();
            Time.timeScale = 1;
            _soundOperator.UnMute();
        }

        private void OnCloseCallback()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:ButtonSubscribe:VideoSub:Close");
            UnLockGame();
        }

        private void OnErrorCallback(string description)
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:ButtonSubscribe:VideoSub:Error:{description}");
            UnLockGame();
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