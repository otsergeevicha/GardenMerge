using CrazyGames;
using GameAnalyticsSDK;
using Infrastructure.SaveLoadLogic;
using Services.HUD.Canvases.AlmanacLogic;
using Services.Sound;
using UnityEngine;

namespace Services.HUD.Canvases.CoinsStore
{
    public class Reward7500Coins : MonoBehaviour
    {
        [SerializeField] private CanvasCoinsStore _coinsStore;
        [SerializeField] private SaveLoad _saveLoad;
        [SerializeField] private SoundOperator _soundOperator;
        [SerializeField] private CanvasHud _canvasHud;
        
        private const int RewardMoney = 7500;

        public void See()
        {
            if (_coinsStore.TryGetVegetation((int)WorkingLevelVegetation.ShrubGold))
            {
                LockGame();
                _soundOperator.Mute();
                GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:Reward:7500:Open");
                CrazyAds.Instance.beginAdBreakRewarded(CompletedCallback, ErrorCallback);
            }
        }

        private void CompletedCallback()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:Reward:7500:Success");

            _saveLoad.ApplyMoneyGift(RewardMoney);
            UnLockGame();
            _soundOperator.UnMute();
        }

        private void ErrorCallback()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:Reward:7500:Error");

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