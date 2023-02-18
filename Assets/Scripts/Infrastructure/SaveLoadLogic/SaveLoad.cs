using UnityEngine;

namespace Infrastructure.SaveLoadLogic
{
    public class SaveLoad : MonoBehaviour
    {
        private const string Key = "Key";
        
        private DataBase _dataBase;

        private void OnEnable()
        {
            _dataBase = PlayerPrefs.HasKey(Key)
                ? JsonUtility.FromJson<DataBase>(PlayerPrefs.GetString(Key))
                : new DataBase();
        }

        private void OnDisable() => 
            Save();
        
        public void ApplyMoney(int money) => 
            _dataBase.Add(money);

        public void BuySeed(int currentPrice) => 
            _dataBase.SpendMoney(currentPrice);

        public bool CheckAmountMoney(int scaleBuying) => 
            _dataBase.GetPrice() > scaleBuying;


        public int ReadAmountWallet() => 
            _dataBase.GetAmountWallet();
        
        public int ReadPriceSeed() => 
            _dataBase.GetPrice();

        public void SaveNewPriceSeed(int currentPrice) => 
            _dataBase.ChangePriceSeed(currentPrice);

        public void Save()
        {
            PlayerPrefs.SetString(Key, JsonUtility.ToJson(_dataBase));
            PlayerPrefs.Save();
        }
    }
}