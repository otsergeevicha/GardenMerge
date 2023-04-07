using Agava.YandexGames;
using Infrastructure.SaveLoadLogic;
using UnityEngine;

namespace Services.Yandex
{
    public class InApp : MonoBehaviour
    {
        [SerializeField] private SaveLoad _saveLoad;

        private const string Subscribe = "subscribe";

        private void Awake()
        { 
            // Billing.GetPurchasedProducts(OnSuccessCallback);
print("залочена проверка покупок");
            if (_saveLoad.CheckStatusSubscribe())
                return;

            _saveLoad.ChangeStatusSubscribe(false);
        }

        private void OnSuccessCallback(GetPurchasedProductsResponse obj)
        {
            foreach (var purchasedProduct in obj.purchasedProducts)
                if (purchasedProduct.productID == Subscribe)
                    _saveLoad.ChangeStatusSubscribe(true);
        }
    }
}