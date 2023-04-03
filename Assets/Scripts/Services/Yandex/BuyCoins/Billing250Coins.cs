using System;
using Agava.YandexGames;
using Infrastructure.SaveLoadLogic;
using UnityEngine;

namespace Services.Yandex.BuyCoins
{
    public class Billing250Coins : MonoBehaviour
    {
        [SerializeField] private SaveLoad _saveLoad;

        public void Buy250Coins()
        {
            if (PlayerAccount.IsAuthorized == false)
                PlayerAccount.Authorize();

            if (PlayerAccount.IsAuthorized)
                Billing.PurchaseProduct("250coins", OnSuccessCallback, OnErrorCallback);
        }

        private void OnSuccessCallback(PurchaseProductResponse obj) =>
            _saveLoad.ApplyMoney(250);

        private void OnErrorCallback(string obj) =>
            throw new NotImplementedException();
    }
}