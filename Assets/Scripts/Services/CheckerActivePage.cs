using Agava.WebUtility;
using Agava.YandexGames;
using Services.Sound;
using UnityEngine;

namespace Services
{
    public class CheckerActivePage : MonoBehaviour
    {
        [SerializeField] private SoundOperator _soundOperator;

        private void OnEnable() => 
            WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;

        private void OnDisable() => 
            WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
        
        private void OnInBackgroundChange(bool inBackground)
        {
            switch (inBackground)
            {
                case true:
                    _soundOperator.Mute();
                    Time.timeScale = 0;
                    break;
                case false:
                    InterstitialAd.Show(OnOpenCallback, OnCloseCallback, OnErrorCallback);
                    Time.timeScale = 1;
                    _soundOperator.UnMute();
                    break;
            }
        }

        private void OnErrorCallback(string obj)
        {
            Time.timeScale = 1;
            _soundOperator.UnMute();
        }

        private void OnCloseCallback(bool obj)
        {
            Time.timeScale = 1;
            _soundOperator.UnMute();
        }

        private void OnOpenCallback()
        {
            _soundOperator.Mute();
            Time.timeScale = 0;
        }
    }
}