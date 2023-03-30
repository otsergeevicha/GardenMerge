using Agava.YandexGames;
using Infrastructure.SaveLoadLogic;
using Services.Sound;
using UnityEngine;

namespace Services.ADS
{
    public class RewardAds : MonoBehaviour
    {
        [SerializeField] private SoundOperator _soundOperator;
        [SerializeField] private SaveLoad _saveLoad;

        private const int BonusCoins = 25;

        public void See() => 
            VideoAd.Show(OnOpenCallback, OnRewardedCallback, OnCloseCallback, OnErrorCallback);

        private void OnOpenCallback()
        {
            Time.timeScale = 0;
            _soundOperator.Mute();
        }

        private void OnRewardedCallback()
        { 
            _saveLoad.ApplyMoney(BonusCoins);
            UnLockGame();
        }

        private void OnCloseCallback() => 
            UnLockGame();

        private void OnErrorCallback(string obj)
        {
            Debug.Log(obj);
            UnLockGame();
        }

        private void UnLockGame()
        {
            Time.timeScale = 1;
            _soundOperator.UnMute();
        }
    }
}