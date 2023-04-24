using Agava.YandexGames;
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
            
            VideoAd.Show(OnOpenCallback, OnRewardedCallback, OnCloseCallback, OnErrorCallback);
        }

        private void OnOpenCallback() => 
            GameAnalytics.NewDesignEvent($"ButtonClick:CanvasKit:VideoAd:Open");

        private void OnRewardedCallback()
        { 
            GameAnalytics.NewDesignEvent($"ButtonClick:CanvasKit:VideoAd:Reward");
            _saveLoad.ApplyMoneyGift(BonusCoins);
        }

        private void OnCloseCallback()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:CanvasKit:VideoAd:Close");
            
            UnLockGame();
        }

        private void OnErrorCallback(string description)
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:CanvasKit:VideoAd:Error:{description}");
            
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