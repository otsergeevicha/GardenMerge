using System;
using Agava.YandexGames;
using GameAnalyticsSDK;
using Infrastructure.SaveLoadLogic;
using UnityEngine;

namespace Services.Yandex.BuyCoins
{
    public class Billing250Coins : MonoBehaviour
    {
        [SerializeField] private SaveLoad _saveLoad;

        public void Buy2500Coins()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:2500:Open");
            
            if (PlayerAccount.IsAuthorized == false)
                PlayerAccount.Authorize();

            if (PlayerAccount.IsAuthorized)
                Billing.PurchaseProduct("250coins", OnSuccessCallback, OnErrorCallback);
        }

        private void OnSuccessCallback(PurchaseProductResponse obj)
        {
            _saveLoad.ApplyMoneyGift(2500);
            GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:2500:Success");
        }

        private void OnErrorCallback(string description) => 
            GameAnalytics.NewDesignEvent($"ButtonClick:BuyCoins:2500:Error:{description}");
    }
}