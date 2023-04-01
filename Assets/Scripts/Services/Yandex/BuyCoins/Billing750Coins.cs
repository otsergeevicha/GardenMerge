using Agava.YandexGames;
using Infrastructure.SaveLoadLogic;
using UnityEngine;

namespace Services.Yandex.BuyCoins
{
    public class Billing750Coins : MonoBehaviour
    {
        [SerializeField] private SaveLoad _saveLoad;

        public void Buy750Coins() =>
            Billing.PurchaseProduct("750coins", OnSuccessCallback, OnErrorCallback);

        private void OnSuccessCallback(PurchaseProductResponse obj) => 
            _saveLoad.ApplyMoney(750);

        private void OnErrorCallback(string obj) => 
            throw new System.NotImplementedException();
    }
}