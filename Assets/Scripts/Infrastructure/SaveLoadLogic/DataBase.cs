using System;

namespace Infrastructure.SaveLoadLogic
{
    [Serializable]
    public class DataBase
    {
        private int _money = 0;
        private int _priceSeed = 1;

        public void Add(int money) => 
            _money += money;

        public void SpendMoney(int money)
        {
            if (money <= _money) 
                _money -= money;
        }

        public void ChangePriceSeed(int price) => 
            _priceSeed = price;

        public int GetPrice() => 
            _money;

        public int GetAmountWallet() =>
            _money;

    }
}