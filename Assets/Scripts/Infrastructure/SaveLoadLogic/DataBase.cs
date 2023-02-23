using System;
using System.Collections.Generic;
using Field.Plants;
using UnityEngine;

namespace Infrastructure.SaveLoadLogic
{
    [Serializable]
    public class DataBase
    {
        public int Money = 100;
        public int CountSpins;
        public int PriceSeed = 1;

        public List<LevelData> LevelDatas = new ();

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
    }
}