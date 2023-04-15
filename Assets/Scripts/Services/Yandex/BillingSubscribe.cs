using Agava.YandexGames;
using GameAnalyticsSDK;
using Infrastructure.SaveLoadLogic;
using UnityEngine;
using UnityEngine.UI;

namespace Services.Yandex
{
    public class BillingSubscribe : MonoBehaviour
    {
        [SerializeField] private SaveLoad _saveLoad;
        [SerializeField] private Button _buttonSubscribe;

        private const int BonusLeaderboardPoints = 1000;
        private const int BonusCoins = 500;
        
        public void BuySubscribe()
        {
            if (PlayerAccount.IsAuthorized == false)
            {
                GameAnalytics.NewDesignEvent($"ButtonClick:ButtonSubscribe:InAppSub:NoAuthorization");
                PlayerAccount.Authorize();
            }

            if (PlayerAccount.IsAuthorized)
                Billing.PurchaseProduct("subscribe", OnSuccessCallback, OnErrorCallback);
        }

        private void OnSuccessCallback(PurchaseProductResponse obj)
        {
            _saveLoad.ApplyPointMerge(BonusLeaderboardPoints);
            _saveLoad.ApplyPointCollect(BonusLeaderboardPoints);
            _saveLoad.ApplyMoneyGift(BonusCoins);
            _saveLoad.ChangeStatusSubscribe(true);
            _buttonSubscribe.interactable = false;
            
            GameAnalytics.NewDesignEvent($"ButtonClick:ButtonSubscribe:InAppSub:Success");
        }

        private void OnErrorCallback(string description)
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:ButtonSubscribe:InAppSub:Error:{description}");
            
            _saveLoad.ChangeStatusSubscribe(false);
        }
    }
}