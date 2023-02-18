using Infrastructure.SaveLoadLogic;
using TMPro;
using UnityEngine;

namespace Services.HUD
{
    public class ViewGold : MonoBehaviour
    {
        [SerializeField] private SaveLoad _saveLoad;
        [SerializeField] private TMP_Text _tmp;
        
        private int _currentAmount;

        private void Start() => 
            Drawing();

        private void Drawing()
        {
            _currentAmount = _saveLoad.ReadAmountWallet();
            _tmp.text = _currentAmount.ToString();
        }

        private void Update()
        {
            if (_currentAmount == _saveLoad.ReadAmountWallet())
                return;
            
            Drawing();
        }
    }
}