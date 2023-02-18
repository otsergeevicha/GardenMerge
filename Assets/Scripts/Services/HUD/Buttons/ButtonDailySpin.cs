using System;
using Infrastructure.SaveLoadLogic;
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

        private const int RewardSpinsADS = 3;
        private const int MaxCountSpins = 3;

        private int _counterSpins = 0;

        private void Start()
        {
            // _counterSpins = _saveLoad.GetCountSpins();

            if (_counterSpins > MaxCountSpins)
                _counterSpins = MaxCountSpins;

            _iconReward.gameObject.SetActive(_counterSpins == 0);

            Draw();
        }

        // private void OnDisable() => _saveLoad.SaveCountSpins(_counterSpins);

        public bool CanSpin()
        {
            if (_counterSpins > 0)
            {
                _counterSpins--;
                Draw();
                _iconReward.gameObject.SetActive(false);
                return true;
            }

            _iconReward.gameObject.SetActive(true);
            Draw();
            return false;
        }

        public void GetSpin()
        {
            //Сейчас всегда +3, далее только через рекламу
            _counterSpins += RewardSpinsADS;
        }

        private void Draw() =>
            _tmpCountSpins.text = $"{_counterSpins.ToString()}/3";
    }
}