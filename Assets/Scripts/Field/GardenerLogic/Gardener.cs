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


        public int ReadAmountWallet() => 
            _wallet.Read();
    }
} 