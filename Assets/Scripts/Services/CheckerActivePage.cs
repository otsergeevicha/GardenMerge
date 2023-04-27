using Agava.WebUtility;
using CrazyGames;
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
                    CrazyEvents.Instance.GameplayStop();
                    _soundOperator.Mute();
                    Time.timeScale = 0;
                    break;
                case false:
                    CrazyEvents.Instance.GameplayStart();
                    Time.timeScale = 1;
                    _soundOperator.UnMute();
                    break;
            }
        }
    }
}