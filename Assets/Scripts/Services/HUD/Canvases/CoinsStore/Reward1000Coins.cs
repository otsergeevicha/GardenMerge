using Agava.YandexGames;
using GameAnalyticsSDK;
using Infrastructure.SaveLoadLogic;
using Services.HUD.Canvases.AlmanacLogic;
using Services.Sound;
using UnityEngine;

namespace Services.HUD.Canvases.CoinsStore
{
    public class Reward1000Coins : MonoBehaviour
    {
        [SerializeField] private CanvasCoinsStore _coinsStore;
        [SerializeField] private SaveLoad _saveLoad;
        [SerializeField] private SoundOperator _soundOperator;
        [SerializeField] private CanvasHud _canvasHud;
        
        private const int RewardMoney = 1000;

        public void See()
        {
            if (_coinsStore.TryGetVegetation((int)WorkingLevelVegetation.ShrubBronze))
            {
                LockGame();
                _soundOperator.Mute();
                VideoAd.Show(OnOpenCallback, OnRewardedCallback, OnCloseCallback, OnErrorCallback);
            }
        }

        private void OnOpenCallback() => 
            GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:Reward:1000:Open");

        private void OnRewardedCallback()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:Reward:1000:Success");
            _saveLoad.ApplyMoneyGift(RewardMoney);
        }

        private void OnCloseCallback()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:Reward:1000:Close");
            UnLockGame();
            _soundOperator.UnMute();
        }

        private void OnErrorCallback(string description)
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:Reward:1000:Error");
            UnLockGame();
            _soundOperator.UnMute();
        }
        
        private void UnLockGame()
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
            _canvasHud.gameObject.SetActive(true);
        }

        private void LockGame()
        {
            Time.timeScale = 0;
            gameObject.SetActive(true);
            _canvasHud.gameObject.SetActive(false);
        }
    }
}