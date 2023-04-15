using Agava.YandexGames;
using GameAnalyticsSDK;
using Infrastructure.SaveLoadLogic;
using UnityEngine;

namespace Services.Yandex.BuyCoins
{
    public class Billing750Coins : MonoBehaviour
    {
        [SerializeField] private SaveLoad _saveLoad;

        public void Buy7500Coins()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:7500:Open");
            
            if (PlayerAccount.IsAuthorized == false)
                PlayerAccount.Authorize();

            if (PlayerAccount.IsAuthorized)
                Billing.PurchaseProduct("750coins", OnSuccessCallback, OnErrorCallback);
        }

        private void OnSuccessCallback(PurchaseProductResponse obj)
        {
            _saveLoad.ApplyMoneyGift(7500);
            GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:7500:Success");
        }

        private void OnErrorCallback(string description) => 
            GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:7500:Error:{description}");
    }
}