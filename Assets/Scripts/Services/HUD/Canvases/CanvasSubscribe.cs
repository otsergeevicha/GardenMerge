using Infrastructure.SaveLoadLogic;
using Services.ADS;
using UnityEngine;

namespace Services.HUD.Canvases
{
    public class CanvasSubscribe : MonoBehaviour
    {
        [SerializeField] private RewardAds _ads;
        [SerializeField] private SaveLoad _saveLoad;

        private const int BonusLeaderboardPoints = 1000;
        private const int BonusCoins = 500;
        
        public bool TemporarySubscription;
        
        public void BuySubscribe()
        {
            if (_ads.TryCanPurchase())
            {
                _saveLoad.ApplyPoint(BonusLeaderboardPoints);
                _saveLoad.ApplyMoney(BonusCoins);
                _saveLoad.ChangeStatusSubscribe(true);
            }

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