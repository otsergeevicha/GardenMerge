using Field.Tiles.Move;
using Infrastructure.Factory;
using Infrastructure.SaveLoadLogic;
using Services.HUD.Canvases.Training;
using TMPro;
using UnityEngine;

namespace Services.HUD.Buttons
{
    public class ButtonSeed : MonoBehaviour
    {
        [SerializeField] private TileMerge[] _tileMerges;

        [SerializeField] private SeedFactory _seedFactory;
        [SerializeField] private TMP_Text _tmp;

        [SerializeField] private SaveLoad _saveLoad;

        [SerializeField] private TrainingScenario _trainingScenario;

        [SerializeField] private IconShake _iconShakeStore;
        [SerializeField] private IconShake _iconShakeButtonAdd;

        private const int LevelBuying = 1;

        private int _currentPrice = 5;
        private bool _firstBuy;
        private bool _secondBuy = true;

        private void Start()
        {
            _currentPrice = _saveLoad.ReadPriceSeed();
            _tmp.text = _currentPrice.ToString();
        }

        public void Buy()
        {
            if (_saveLoad.CheckAmountMoney(_currentPrice) && TryFreePlace())
            {
                _saveLoad.BuySeed(_currentPrice);
                _currentPrice++;
                _saveLoad.SaveNewPriceSeed(_currentPrice);
                _tmp.text = _currentPrice.ToString();

                if (_saveLoad.ReadFirstTraining())
                {
                    _firstBuy = true;
                    _secondBuy = true;
                }

                if (_saveLoad.ReadFirstTraining() == false)
                    WorkTrainingAI();
            }
            else
            {
                _iconShakeStore.Shake();
                _iconShakeButtonAdd.Shake();
            }
        }

        private void WorkTrainingAI()
        {
            if (_secondBuy == false)
            {
                _trainingScenario.CompletedTwoStep();
                _secondBuy = true;
            }

            if (_firstBuy == false)
            {
                _trainingScenario.CompletedOneStep();
                _firstBuy = true;
                _secondBuy = false;
            }
        }

        private bool TryFreePlace()
        {
            foreach (TileMerge tile in _tileMerges)
            {
                if (tile.CheckStatusPlace())
                {
                    Vector3 placeSpawn = tile.transform.position;

                    foreach (var plant in _seedFactory.GetAllPlants())
                    {
                        if (plant.GetLevel() == LevelBuying && plant.gameObject.activeInHierarchy == false)
                        {
                            plant.gameObject.transform.position = placeSpawn;
                            plant.gameObject.SetActive(true);
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}