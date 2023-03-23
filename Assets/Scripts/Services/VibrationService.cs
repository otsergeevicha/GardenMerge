using System;
using Infrastructure.SaveLoadLogic;
using UnityEngine;
using UnityEngine.UI;

namespace Services
{
    public class VibrationService : MonoBehaviour
    {
        [SerializeField] private Toggle _toggle;
        
        [SerializeField] private RectTransform _transformToggle;
        [SerializeField] private Image _background;
        
        [SerializeField] private SaveLoad _saveLoad;

        private void Start()
        {
            if (_saveLoad.ReadStatusVibration())
            {
                _transformToggle.anchoredPosition = new Vector2(43.1f, -5.4f);
                _background.color = Color.white;
            }

            if (_saveLoad.ReadStatusVibration() == false)
            {
                _transformToggle.anchoredPosition = new Vector2(-43.1f, -5.4f);
                _background.color = Color.red;
            }
        }

        public void SwitcherVibration()
        {
            switch (_toggle.isOn)
            {
                case true:
                    _transformToggle.anchoredPosition = new Vector2(43.1f, -5.4f);
                    _background.color = Color.white;
                    _saveLoad.SaveStatusVibration(_toggle.isOn);
                    break;
                case false:
                    _transformToggle.anchoredPosition = new Vector2(-43.1f, -5.4f);
                    _background.color = Color.red;
                    _saveLoad.SaveStatusVibration(_toggle.isOn);
                    break;
            }
        }

        public void OnTick()
        {
            // if (_toggle.isOn) Handheld.Vibrate();
        }
    }
}