using Infrastructure.SaveLoadLogic;
using Services.ADS;
using UnityEngine;

namespace Services.HUD.Canvases
{
    public class CanvasSubscribe : MonoBehaviour
    {
        [SerializeField] private RewardAds _ads;
        [SerializeField] private SaveLoad _saveLoad;

        public bool TemporarySubscription;
        
        public void BuySubscribe()
        {
            if (_ads.TryCanPurchase())
                _saveLoad.ChangeStatusSubscribe(true);

            if (_ads.TryCanPurchase() == false)
                _saveLoad.ChangeStatusSubscribe(false);
        }

        public void SubscribeAdvertising()
        {
            if (_ads.TryCanADS())
            {
                _saveLoad.ChangeStatusSubscribe(true);
                TemporarySubscription = true;
            }
        }
    }
}