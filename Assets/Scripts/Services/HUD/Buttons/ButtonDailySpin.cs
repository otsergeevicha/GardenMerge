using Infrastructure.SaveLoadLogic;
using Services.ADS;
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

        [SerializeField] private RewardAds _rewardAds;

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

        public void GetSpin()
        {
            //Сейчас всегда +3, далее только через рекламу
            print("Место где должен быть Reward за спины");

            if (_rewardAds.TryCanADS())
            {
                _counterSpins += RewardSpinsADS;
            
                if (_counterSpins > MaxCountSpins)
                    _counterSpins = MaxCountSpins;
            }
        }

        private void Draw() =>
            _tmpCountSpins.text = $"{_counterSpins.ToString()}/3";
    }
}