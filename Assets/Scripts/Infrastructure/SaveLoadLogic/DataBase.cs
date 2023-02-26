using System;
using System.Collections.Generic;
using Field.Plants;

namespace Infrastructure.SaveLoadLogic
{
    [Serializable]
    public class DataBase
    {
        public List<LevelData> LevelDatas = new ();
        
        public int Money { get; private set; } = 100;
        public int CountSpins { get; private set; }
        public int PriceSeed { get; private set; } = 1;
        public int Score { get; private set; }
        
        public void SpendMoney(int money)
        {
            if (money <= Money)
                Money -= money;
        }

        public void Add(int money) =>
            Money += money;

        public void ChangePriceSeed(int price) =>
            PriceSeed = price;

        public int GetPrice() =>
            Money;

        public int GetAmountWallet() =>
            Money;

        public int ReadCountSpins() =>
            CountSpins;

        public void ChangeCountSpins(int counterSpins) =>
            CountSpins = counterSpins;

        public int GetPriceSeed() =>
            PriceSeed;

        public List<LevelData> ReadAllVegetation() =>
            LevelDatas;

        public void SaveVegetation(List<Vegetation> getAllPlants)
        {
            LevelDatas.Clear();

            foreach (Vegetation vegetation in getAllPlants)
            {
                if (vegetation.isActiveAndEnabled)
                {
                    LevelDatas.Add(new LevelData(vegetation.GetLevel(), vegetation.transform.position));
                }
            }
        }

        public void AddPoints(int amountPoints) => 
            Score += amountPoints;

        public int GetScore() => 
            Score;
    }
}