using DungeonGames.VKGames;
using GameAnalyticsSDK;
using Infrastructure.SaveLoadLogic;
using Services.HUD.Canvases;
using Services.Sound;
using UnityEngine;

namespace Services.ADS
{
    public class RewardAds : MonoBehaviour
    {
        [SerializeField] private SoundOperator _soundOperator;
        [SerializeField] private SaveLoad _saveLoad;
        [SerializeField] private CanvasKit _canvasKit;

        private const int BonusCoins = 500;

        public void See()
        {
            Time.timeScale = 0;
            _soundOperator.Mute();
            
            VideoAd.Show(OnRewardedCallback, OnErrorCallback);
        }

        private void OnRewardedCallback()
        { 
            GameAnalytics.NewDesignEvent($"ButtonClick:CanvasKit:VideoAd:Reward");
            _saveLoad.ApplyMoneyGift(BonusCoins);
        }

        private void OnErrorCallback()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:CanvasKit:VideoAd:Error");
            UnLockGame();
        }

        private void UnLockGame()
        {
            Time.timeScale = 1;
            _soundOperator.UnMute();
            _canvasKit.OffVisible();
        }
    }
}