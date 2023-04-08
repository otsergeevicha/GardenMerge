using System.Collections;
using System.Linq;
using Agava.YandexGames;
using Field.Plants;
using Infrastructure.Factory;
using UnityEngine;

namespace Infrastructure.SaveLoadLogic
{
    public class SaveLoad : MonoBehaviour
    {
        [SerializeField] private OperatorFactory _factory;

        private const string Key = "Key";

        private readonly WaitForSeconds _waitForSeconds = new(5f);

        private bool _isOnApplication;

        private DataBase _dataBase;
        private Coroutine _coroutine;

        private void OnEnable()
        {
            _dataBase = PlayerPrefs.HasKey(Key)
                    ? JsonUtility.FromJson<DataBase>(PlayerPrefs.GetString(Key))
                    : new DataBase();
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

        public void ApplyPointMerge(int amountPoints) =>
            _dataBase.AddPointsMerge(amountPoints);

        public int ReadScoreMerge() =>
            _dataBase.GetScoreMerge();

        public void ApplyPointCollect(int amountPoints) =>
            _dataBase.AddPointsCollect(amountPoints);

        public int ReadScoreCollect() =>
            _dataBase.GetScoreCollect();

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

        public void ChangeStatusTempSubscribe(bool status) => 
            _dataBase.ChangeTempSubscribeStatus(status);

        public int ReadPriceSeed() =>
            _dataBase.GetPriceSeed();

        public int GetCountSpins() =>
            _dataBase.ReadCountSpins();

        public float ReadValueFxSound() =>
            _dataBase.ValueFX;

        public float ReadValueMusic() =>
            _dataBase.ValueMusic;

        public void SaveStatusVibration(bool isVibration) =>
            _dataBase.ChangeStatusVibration(isVibration);

        public bool ReadStatusVibration() =>
            _dataBase.IsVibration;

        public bool ReadStatusSubscribe() =>
            _dataBase.IsSubscribe;
        
        public bool ReadTempStatusSubscribe() =>
            _dataBase.IsTempSubscribe;

        public bool ReadFirstTraining() => 
            _dataBase.FirstTraining;

        public void Save()
        {
            string data = JsonUtility.ToJson(_dataBase);
            
            PlayerPrefs.SetString(Key, data);
            PlayerPrefs.Save();
            
           // PlayerAccount.SetPlayerData(data);
            print("залочено облачное сохранение");
        }

        public void ChangeStatusFirstTraining(bool status) => 
            _dataBase.FirstTraining = status;

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