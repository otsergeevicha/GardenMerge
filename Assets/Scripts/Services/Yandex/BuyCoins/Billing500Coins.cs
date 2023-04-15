using Agava.YandexGames;
using GameAnalyticsSDK;
using Infrastructure.SaveLoadLogic;
using UnityEngine;

namespace Services.Yandex.BuyCoins
{
    public class Billing500Coins : MonoBehaviour
    {
        [SerializeField] private SaveLoad _saveLoad;

        public void Buy5000Coins()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:5000:Open");
            
            if (PlayerAccount.IsAuthorized == false)
                PlayerAccount.Authorize();

            if (PlayerAccount.IsAuthorized)
                Billing.PurchaseProduct("500coins", OnSuccessCallback, OnErrorCallback);
        }

        private void OnSuccessCallback(PurchaseProductResponse obj)
        {
            _saveLoad.ApplyMoneyGift(5000);
            GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:5000:Success");
        }

        private void OnErrorCallback(string description) => 
            GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:5000:Error:{description}");
    }
}