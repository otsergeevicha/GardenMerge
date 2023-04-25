using DungeonGames.VKGames;
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
            Time.timeScale = 0;
            _soundOperator.Mute();
            
            VideoAd.Show(OnRewardedCallback, OnErrorCallback);
        }
        
        private void OnRewardedCallback()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:ButtonSubscribe:VideoSub:Reward");
            
            _customTimer.Status = true;
            _saveLoad.ChangeStatusSubscribe(true);
            _saveLoad.ChangeStatusTempSubscribe(true);
            _subscribe.OffVisibleCanvas();
            UnLockGame();
        }

        private void OnErrorCallback()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:ButtonSubscribe:VideoSub:Error");
            _subscribe.OffVisibleCanvas();
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