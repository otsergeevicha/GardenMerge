using Agava.YandexGames;
using GameAnalyticsSDK;
using Infrastructure.SaveLoadLogic;
using UnityEngine;

namespace Services.Yandex.BuyCoins
{
    public class Billing1000Coins : MonoBehaviour
    {
        [SerializeField] private SaveLoad _saveLoad;

        public void Buy10000Coins()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:10000:Open");
            
            if (PlayerAccount.IsAuthorized == false)
                PlayerAccount.Authorize();

            if (PlayerAccount.IsAuthorized)
                Billing.PurchaseProduct("1000coins", OnSuccessCallback, OnErrorCallback);
        }

        private void OnSuccessCallback(PurchaseProductResponse obj)
        {
            _saveLoad.ApplyMoneyGift(10000);
            GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:10000:Success");
        }

        private void OnErrorCallback(string description) => 
            GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:10000:Error:{description}");
    }
}