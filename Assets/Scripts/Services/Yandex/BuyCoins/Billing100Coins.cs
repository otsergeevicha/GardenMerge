using System;
using Agava.YandexGames;
using GameAnalyticsSDK;
using Infrastructure.SaveLoadLogic;
using UnityEngine;

namespace Services.Yandex.BuyCoins
{
    public class Billing100Coins : MonoBehaviour
    {
        [SerializeField] private SaveLoad _saveLoad;

        public void Buy1000Coins()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:1000:Open");
            
            if (PlayerAccount.IsAuthorized == false)
                PlayerAccount.Authorize();

            if (PlayerAccount.IsAuthorized)
                Billing.PurchaseProduct("100coins", OnSuccessCallback, OnErrorCallback);
        }

        private void OnSuccessCallback(PurchaseProductResponse obj)
        {
            _saveLoad.ApplyMoneyGift(1000);
            GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:1000:Success");
        }

        private void OnErrorCallback(string description) => 
            GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:1000:Error:{description}");
    }
}