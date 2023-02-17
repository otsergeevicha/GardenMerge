using System;
using Field.GardenerLogic.StateMachine;
using Field.GardenerLogic.WalletGardener;
using UnityEngine;

namespace Field.GardenerLogic
{
    [RequireComponent(typeof(StateMachineGardener))]
    public class Gardener : MonoBehaviour
    {
        private Wallet _wallet;

        private void Start() => 
            _wallet = new Wallet();

        public void ApplyMoney(int money) => 
            _wallet.Add(money);

        public void BuySeed(int currentPrice) => 
            _wallet.SpendMoney(currentPrice);

        public bool CheckAmountMoney(int scaleBuying) => 
            _wallet.Read() > 0;
    }

    public class SaveLoad : MonoBehaviour
    {
        public int ReadPriceSeed()
        {
            throw new NotImplementedException();
        }

        public void SaveNewPriceSeed(int currentPrice)
        {
            throw new NotImplementedException();
        }
    }
}