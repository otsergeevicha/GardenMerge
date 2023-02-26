using Agava.YandexGames;
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
            print("вошли в просмотр");
            VideoAd.Show(OnOpenCallBack,OnRewardCallBack, OnCloseCallBack, OnErrorCallBack);
            return _tryGetReward;
        }
        
        private void OnOpenCallBack()
        {
            print("открыт колбек");
            _isSeeADS = true;
        }

        private void OnRewardCallBack()
        {
            if (_isSeeADS)
            {
                print("оплатили рекламу");
                _isSeeADS = false;
                _tryGetReward = true;
            }
        }

        private void OnCloseCallBack()
        {
        }

        private void OnErrorCallBack(string obj)
        {
            if (_isSeeADS == false)
            {
                _tryGetReward = false;
                print("Месседж о непросмотренной рекламе");
            }
        }
    }
}