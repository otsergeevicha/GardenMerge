using Agava.YandexGames;
using Infrastructure.SaveLoadLogic;
using UnityEngine;

namespace Services.Yandex.BuyCoins
{
    public class Billing1000Coins : MonoBehaviour
    {
        [SerializeField] private SaveLoad _saveLoad;

        public void Buy1000Coins() =>
            Billing.PurchaseProduct("1000coins", OnSuccessCallback, OnErrorCallback);

        private void OnSuccessCallback(PurchaseProductResponse obj) => 
            _saveLoad.ApplyMoney(1000);

        private void OnErrorCallback(string obj) => 
            throw new System.NotImplementedException();
    }
}