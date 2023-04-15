using Agava.YandexGames;
using GameAnalyticsSDK;
using Infrastructure.SaveLoadLogic;
using Services.Sound;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Services.HUD.Buttons
{
    public class ButtonDailySpin : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tmpCountSpins;
        [SerializeField] private SaveLoad _saveLoad;
        [SerializeField] private Image _iconReward;

        [SerializeField] private SoundOperator _soundOperator;

        private const int RewardSpinsADS = 3;
        private const int MaxCountSpins = 3;

        private int _counterSpins = 3;

        private void Start() => 
            _counterSpins = _saveLoad.GetCountSpins();

        private void Update()
        {
            if (isActiveAndEnabled == false)
                return;

            if (_counterSpins > MaxCountSpins)
                _counterSpins = MaxCountSpins;

            _iconReward.gameObject.SetActive(_counterSpins == 0);

            Draw();
        }

         private void OnDisable() => 
             _saveLoad.SaveCountSpins(_counterSpins);

        public bool CanSpin()
        {
            if (_counterSpins > 0)
            {
                _counterSpins--;
                Draw();
                return true;
            }

            Draw();
            return false;
        }

        public void See() => 
            VideoAd.Show(OnOpenCallback, OnRewardedCallback, OnCloseCallback, OnErrorCallback);

        private void OnOpenCallback()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:Roulette:CanSpin:Open");
            Time.timeScale = 0;
            _soundOperator.Mute();
        }

        private void OnRewardedCallback()
        { 
            GameAnalytics.NewDesignEvent($"ButtonClick:Roulette:CanSpin:Reward");
            
            _counterSpins += RewardSpinsADS;
            
            if (_counterSpins > MaxCountSpins) 
                _counterSpins = MaxCountSpins;
            
            UnLockGame();
        }

        private void OnCloseCallback()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:Roulette:CanSpin:Close");
            UnLockGame();
        }

        private void OnErrorCallback(string description)
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:Roulette:CanSpin:Error:{description}");
            UnLockGame();
        }

        private void UnLockGame()
        {
            Time.timeScale = 1;
            _soundOperator.UnMute();
        }

        private void Draw() =>
            _tmpCountSpins.text = $"{_counterSpins.ToString()}/3";
    }
}