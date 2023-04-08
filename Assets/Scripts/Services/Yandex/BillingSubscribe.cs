using Agava.YandexGames;
using Infrastructure.SaveLoadLogic;
using UnityEngine;

namespace Services.Yandex
{
    public class BillingSubscribe : MonoBehaviour
    {
        [SerializeField] private SaveLoad _saveLoad;

        private const int BonusLeaderboardPoints = 1000;
        private const int BonusCoins = 500;
        
        public void BuySubscribe()
        {
            if (PlayerAccount.IsAuthorized == false)
                PlayerAccount.Authorize();

            if (PlayerAccount.IsAuthorized)
                Billing.PurchaseProduct("subscribe", OnSuccessCallback, OnErrorCallback);
        }

        private void OnSuccessCallback(PurchaseProductResponse obj)
        {
            _saveLoad.ApplyPointMerge(BonusLeaderboardPoints);
            _saveLoad.ApplyPointCollect(BonusLeaderboardPoints);
            _saveLoad.ApplyMoney(BonusCoins);
            _saveLoad.ChangeStatusSubscribe(true);
        }

        private void OnErrorCallback(string obj) =>
            _saveLoad.ChangeStatusSubscribe(false);
    }
}