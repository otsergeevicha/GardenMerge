using CrazyGames;
using GameAnalyticsSDK;
using Infrastructure.SaveLoadLogic;
using Services.HUD.Canvases.AlmanacLogic;
using Services.Sound;
using UnityEngine;

namespace Services.HUD.Canvases.CoinsStore
{
    public class Reward5000Coins : MonoBehaviour
    {
        [SerializeField] private CanvasCoinsStore _coinsStore;
        [SerializeField] private SaveLoad _saveLoad;
        [SerializeField] private SoundOperator _soundOperator;
        [SerializeField] private CanvasHud _canvasHud;
        
        private const int RewardMoney = 5000;

        public void See()
        {
            if (_coinsStore.TryGetVegetation((int)WorkingLevelVegetation.FlowerGold))
            {
                LockGame();
                _soundOperator.Mute();
                GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:Reward:5000:Open");
                CrazyAds.Instance.beginAdBreakRewarded(CompletedCallback, ErrorCallback);
            }
        }

        private void CompletedCallback()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:Reward:5000:Success");

            _saveLoad.ApplyMoneyGift(RewardMoney);
            UnLockGame();
            _soundOperator.UnMute();
        }

        private void ErrorCallback()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:Reward:5000:Error");

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