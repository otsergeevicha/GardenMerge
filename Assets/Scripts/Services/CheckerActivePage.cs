using Agava.WebUtility;
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

        private void Start()
        {
            Time.timeScale = 1;
            _soundOperator.UnMute();
        }

        private void OnInBackgroundChange(bool inBackground)
        {
            switch (inBackground)
            {
                case true:
                    Time.timeScale = 1;
                    _soundOperator.UnMute();
                    break;
                case false:
                    Time.timeScale = 0;
                    _soundOperator.Mute();
                    break;
            }
        }
    }
}