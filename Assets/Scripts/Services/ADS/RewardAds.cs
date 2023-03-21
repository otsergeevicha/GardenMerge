using Infrastructure.SaveLoadLogic;
using UnityEngine;

namespace Services.ADS
{
    public class RewardAds : MonoBehaviour
    {
        [SerializeField] private SaveLoad _saveLoad;

        private const int BonusCoins = 25;

        private bool _isSeeADS;
        private bool _tryGetReward = false;

        public bool TryCanADS() =>
            SeeReward();

        public void GetCoinsADS()
        {
            if (SeeReward())
                _saveLoad.ApplyMoney(BonusCoins);
        }

        private bool SeeReward()
        {
            print("тут обработка reward рекламы");
            return true;
        }

        public bool TryCanPurchase()
        {
            print("здесь обработка покупки (инапы)");
            return true;
        }
    }
}