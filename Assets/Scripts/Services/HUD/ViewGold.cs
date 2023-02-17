using Field.GardenerLogic;
using TMPro;
using UnityEngine;

namespace Services.HUD
{
    public class ViewGold : MonoBehaviour
    {
        [SerializeField] private Gardener _gardener;
        [SerializeField] private TMP_Text _tmp;
        
        private int _currentAmount;

        private void Start() => 
            Drawing();

        private void Drawing()
        {
            _currentAmount = _gardener.ReadAmountWallet();
            _tmp.text = _currentAmount.ToString();
        }

        private void Update()
        {
            if (_currentAmount == _gardener.ReadAmountWallet())
                return;
            
            Drawing();
        }
    }
}