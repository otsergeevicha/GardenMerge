using System;
using System.Collections.Generic;
using System.Linq;
using Field.Plants;

namespace Infrastructure.SaveLoadLogic
{
    [Serializable]
    public class DataBase
    {
        public List<LevelData> LevelDatas = new ();

        public bool IsVibration;
        public bool IsSubscribe;
        public float ValueMusic;
        public float ValueFX;
        public int Money = 100;
        public int CountSpins;
        public int PriceSeed = 1;
        public int Score;

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

            foreach (var vegetation in getAllPlants.Where(vegetation => vegetation.isActiveAndEnabled))
                LevelDatas.Add(new LevelData(vegetation.GetLevel(), vegetation.transform.position));
        }

        public void AddPoints(int amountPoints) => 
            Score += amountPoints;

        public int GetScore() => 
            Score;

        public void SaveValueFx(float value) => 
            ValueFX = value;

        public void SaveValueMusic(float value) => 
            ValueMusic = value;

        public void ChangeSubscribeStatus(bool status) => 
            IsSubscribe = status;

        public void ChangeStatusVibration(bool isVibration) => 
            IsVibration = isVibration;
    }
}