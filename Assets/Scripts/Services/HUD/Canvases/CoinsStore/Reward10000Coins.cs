using DungeonGames.VKGames;
using GameAnalyticsSDK;
using Infrastructure.SaveLoadLogic;
using Services.HUD.Canvases.AlmanacLogic;
using Services.Sound;
using UnityEngine;

namespace Services.HUD.Canvases.CoinsStore
{
    public class Reward10000Coins : MonoBehaviour
    {
        [SerializeField] private CanvasCoinsStore _coinsStore;
        [SerializeField] private SaveLoad _saveLoad;
        [SerializeField] private SoundOperator _soundOperator;
        [SerializeField] private CanvasHud _canvasHud;
        
        private const int RewardMoney = 10000;

        public void See()
        {
            if (_coinsStore.TryGetVegetation((int)WorkingLevelVegetation.TreeGold))
            {
                LockGame();
                _soundOperator.Mute();
                VideoAd.Show(OnRewardedCallback, OnErrorCallback);
            }
        }

        private void OnRewardedCallback()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:Reward:10000:Success");
            _saveLoad.ApplyMoneyGift(RewardMoney);
            UnLockGame();
            _soundOperator.UnMute();
        }

        private void OnErrorCallback()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:Reward:10000:Error");
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