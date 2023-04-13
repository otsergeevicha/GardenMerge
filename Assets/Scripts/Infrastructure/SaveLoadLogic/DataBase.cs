using System;
using System.Collections.Generic;
using System.Linq;
using Field.Plants;
using Services.HUD.Canvases.AlmanacLogic;

namespace Infrastructure.SaveLoadLogic
{
    [Serializable]
    public class DataBase
    {
        public List<LevelData> LevelDatas = new ();
        public List<AlmanacType> Almanac = new ();

        public bool FirstTraining;
        public bool IsSubscribe;
        public bool IsTempSubscribe;
        public float ValueMusic = .2f;
        public float ValueFX = .2f;
        public int Money = 100;
        public int CountSpins;
        public int PriceSeed = 1;
        public int ScoreMerge;
        public int ScoreCollect;

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

        public void AddPointsMerge(int amountPoints) => 
            ScoreMerge += amountPoints;

        public int GetScoreMerge() => 
            ScoreMerge;
        
        public void AddPointsCollect(int amountPoints) => 
            ScoreCollect += amountPoints;

        public int GetScoreCollect() => 
            ScoreCollect;

        public void SaveValueFx(float value) => 
            ValueFX = value;

        public void SaveValueMusic(float value) => 
            ValueMusic = value;

        public void ChangeSubscribeStatus(bool status) => 
            IsSubscribe = status;

        public void ChangeTempSubscribeStatus(bool status) =>
            IsTempSubscribe = status;

        public void SaveAlmanac(List<AlmanacType> almanac) => 
            Almanac = almanac;
    }
}