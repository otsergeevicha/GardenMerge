using System;

namespace Field.GardenerLogic.WalletGardener
{
    [Serializable]
    public class Wallet
    {
        private int _money = 0;

        public void Add(int money) => 
            _money += money;

        public void SpendMoney(int money)
        {
            if (money <= _money) 
                _money -= money;
        }

        public int Read() => 
            _money;
    }
}