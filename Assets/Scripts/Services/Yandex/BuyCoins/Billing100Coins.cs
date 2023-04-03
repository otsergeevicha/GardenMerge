using System;
using Agava.YandexGames;
using Infrastructure.SaveLoadLogic;
using UnityEngine;

namespace Services.Yandex.BuyCoins
{
    public class Billing100Coins : MonoBehaviour
    {
        [SerializeField] private SaveLoad _saveLoad;

        public void Buy100Coins()
        {
            if (PlayerAccount.IsAuthorized == false)
                PlayerAccount.Authorize();

            if (PlayerAccount.IsAuthorized)
                Billing.PurchaseProduct("100coins", OnSuccessCallback, OnErrorCallback);
        }

        private void OnSuccessCallback(PurchaseProductResponse obj) =>
            _saveLoad.ApplyMoney(100);

        private void OnErrorCallback(string obj) =>
            throw new NotImplementedException();
    }
}