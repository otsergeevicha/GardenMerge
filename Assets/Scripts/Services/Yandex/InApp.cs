using Agava.YandexGames;
using Infrastructure.SaveLoadLogic;
using Lean.Localization;
using UnityEngine;
using UnityEngine.UI;

namespace Services.Yandex
{
    public class InApp : MonoBehaviour
    {
        [SerializeField] private SaveLoad _saveLoad;
        [SerializeField] private Button _buttonSubscribe;

        private const string Subscribe = "subscribe";

        private void Awake()
        { 
            Billing.GetPurchasedProducts(OnSuccessCallback, OnErrorCallback);

           LeanLocalization.SetCurrentLanguageAll(YandexGamesSdk.Environment.i18n.lang);
           LeanLocalization.UpdateTranslations();
            
            if (_saveLoad.ReadStatusSubscribe() && _saveLoad.ReadTempStatusSubscribe() == false)
                return;

            _saveLoad.ChangeStatusSubscribe(false);
        }

        private void OnSuccessCallback(GetPurchasedProductsResponse obj)
        {
            foreach (var purchasedProduct in obj.purchasedProducts)
                if (purchasedProduct.productID == Subscribe)
                {
                    _saveLoad.ChangeStatusSubscribe(true);
                    _buttonSubscribe.interactable = false;
                }
        }

        private void OnErrorCallback(string obj) => 
            _saveLoad.ChangeStatusSubscribe(false);
    }
}