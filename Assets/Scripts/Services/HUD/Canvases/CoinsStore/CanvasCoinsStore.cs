using System.Linq;
using Agava.YandexGames;
using Field.Plants;
using GameAnalyticsSDK;
using Infrastructure.Factory;
using Infrastructure.SaveLoadLogic;
using Services.HUD.Canvases.AlmanacLogic;
using Services.Sound;
using UnityEngine;

namespace Services.HUD.Canvases.CoinsStore
{
    public class CanvasCoinsStore : MonoBehaviour
    {
        [SerializeField] private CanvasKit _canvasKit;
        [SerializeField] private CanvasHud _canvasHud;
        [SerializeField] private OperatorFactory _factory;

        public void OnVisible()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:CoinsStore:Open");
            _canvasKit.OffVisible();
            _canvasHud.gameObject.SetActive(false);
            Time.timeScale = 0;
            gameObject.SetActive(true);
        }

        public void OffVisible()
        {
            _canvasHud.gameObject.SetActive(true);
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }

        public bool TryGetVegetation(int requiredLevel)
        {
            Vegetation vegetation = _factory.GetAllPlants().FirstOrDefault(vegetation =>
                vegetation.GetLevel() == requiredLevel
                && vegetation.isActiveAndEnabled);

            if (vegetation == null)
                return false;

            vegetation.gameObject.SetActive(false);
            return true;
        }
    }

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
                VideoAd.Show(OnOpenCallback, OnRewardedCallback, OnCloseCallback, OnErrorCallback);
        }

        private void OnOpenCallback()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:Reward:1000:Open");
            LockGame();
            _soundOperator.Mute();
        }

        private void OnRewardedCallback()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:Reward:1000:Success");
            _saveLoad.ApplyMoneyGift(RewardMoney);
            UnLockGame();
            _soundOperator.UnMute();
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

    public class Reward2500Coins : MonoBehaviour
    {
        [SerializeField] private CanvasCoinsStore _coinsStore;

        public void See()
        {
            if (_coinsStore.TryGetVegetation((int)WorkingLevelVegetation.TreeBronze))
            {
            }
        }
    }

    public class Reward5000Coins : MonoBehaviour
    {
        [SerializeField] private CanvasCoinsStore _coinsStore;

        public void See()
        {
            if (_coinsStore.TryGetVegetation((int)WorkingLevelVegetation.FlowerGold))
            {
            }
        }
    }

    public class Reward7500Coins : MonoBehaviour
    {
        [SerializeField] private CanvasCoinsStore _coinsStore;

        public void See()
        {
            if (_coinsStore.TryGetVegetation((int)WorkingLevelVegetation.ShrubGold))
            {
            }
        }
    }

    public class Reward10000Coins : MonoBehaviour
    {
        [SerializeField] private CanvasCoinsStore _coinsStore;

        public void See()
        {
            if (_coinsStore.TryGetVegetation((int)WorkingLevelVegetation.TreeGold))
            {
            }
        }
    }
}