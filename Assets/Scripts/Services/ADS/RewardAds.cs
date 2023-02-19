using Infrastructure.SaveLoadLogic;
using UnityEngine;

namespace Services.ADS
{
    public class RewardAds : MonoBehaviour
    {
        [SerializeField] private SaveLoad _saveLoad;

        private const int BonusCoins = 25;
        
        public bool TryCanADS()
        {
            print("здесь будет проверка возможности посмотреть рекламу");
            return true;
        }

        public void GetCoinsADS() 
        {
            print("здесь должны быть прикручена реклама");
            _saveLoad.ApplyMoney(BonusCoins);
        }
    }
}