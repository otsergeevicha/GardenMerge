using System.Collections;
using System.Linq;
using Field.Plants;
using Infrastructure.Factory;
using UnityEngine;

namespace Infrastructure.SaveLoadLogic
{
    public class SaveLoad : MonoBehaviour
    {
        [SerializeField] private OperatorFactory _factory;
        
        private const string Key = "Key";
        
        private readonly WaitForSeconds _waitForSeconds = new (5f);
        
        private DataBase _dataBase;
        private Coroutine _coroutine;
        private bool _isOnApplication;

        private void OnEnable()
        {
            _dataBase = PlayerPrefs.HasKey(Key)
                ? JsonUtility.FromJson<DataBase>(PlayerPrefs.GetString(Key))
                : new DataBase();
        }

        private void Start()
        {
            SpawnVegetation();

            _coroutine = StartCoroutine(AutoSaveVegetation());
        }

        private void SpawnVegetation()
        {
            foreach (LevelData levelData in _dataBase.ReadAllVegetation())
            {
                Vegetation vegetation = _factory.GetAllPlants().FirstOrDefault(vegetation =>
                    vegetation.isActiveAndEnabled == false
                    && vegetation.GetLevel() == levelData.LevelVegetation);

                if (vegetation != null)
                {
                    vegetation.gameObject.SetActive(true);
                    vegetation.InitPosition(levelData.PositionVegetation);
                }
            }
        }

        private void OnDisable()
        {
            if (_coroutine != null)
            {
                _isOnApplication = false;
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
            
            Save();
        }

        public void ApplyMoney(int money)
        {
            if (_dataBase.IsSubscribe) 
                _dataBase.Add(money * 2);

            if (_dataBase.IsSubscribe == false) 
                _dataBase.Add(money);

            Save();
        }

        public void BuySeed(int currentPrice)
        {
            _dataBase.SpendMoney(currentPrice);
            Save();
        }

        public void SaveNewPriceSeed(int currentPrice)
        {
            _dataBase.ChangePriceSeed(currentPrice);
            Save();
        }

        public void SaveCountSpins(int counterSpins) => 
            _dataBase.ChangeCountSpins(counterSpins);

        public void ApplyPoint(int amountPoints) => 
            _dataBase.AddPoints(amountPoints);

        public void SaveValueFxSound(float value)
        {
            _dataBase.SaveValueFx(value);
            Save();
        }

        public void SaveValueMusic(float value)
        {
            _dataBase.SaveValueMusic(value);
            Save();
        }

        public bool CheckAmountMoney(int scaleBuying) => 
            _dataBase.GetPrice() > scaleBuying;

        public int ReadAmountWallet() => 
            _dataBase.GetAmountWallet();

        public void ChangeStatusSubscribe(bool status) => 
            _dataBase.ChangeSubscribeStatus(status);

        public int ReadPriceSeed() => 
            _dataBase.GetPriceSeed();

        public int GetCountSpins() => 
            _dataBase.ReadCountSpins();

        public int ReadScore() => 
            _dataBase.GetScore();

        public float ReadValueFxSound() => 
            _dataBase.ValueFX;

        public float ReadValueMusic() => 
            _dataBase.ValueMusic;

        public void SaveStatusVibration(bool isVibration) => 
            _dataBase.ChangeStatusVibration(isVibration);

        public void Save()
        {
            PlayerPrefs.SetString(Key, JsonUtility.ToJson(_dataBase));
            PlayerPrefs.Save();
        }

        private IEnumerator AutoSaveVegetation()
        {
            _isOnApplication = true;
            
            while (_isOnApplication)
            {
                _dataBase.SaveVegetation(_factory.GetAllPlants());
                yield return _waitForSeconds;
            }
        }
    }
}