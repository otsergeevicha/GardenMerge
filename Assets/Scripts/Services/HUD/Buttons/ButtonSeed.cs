using Field.Tiles.Move;
using Infrastructure.Factory;
using Infrastructure.SaveLoadLogic;
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
        
        [SerializeField] private VibrationService _vibrationService;
        
        private const int LevelBuying = 1;
        
        private int _currentPrice = 5;

        private void Start()
        {
            _currentPrice = _saveLoad.ReadPriceSeed();
            _tmp.text = _currentPrice.ToString();
        }

        public void Buy()
        {
            if (_saveLoad.CheckAmountMoney(_currentPrice) && TryFreePlace())
            {
                _currentPrice++;
                _saveLoad.SaveNewPriceSeed(_currentPrice);
                _saveLoad.BuySeed(_currentPrice);
                _tmp.text = _currentPrice.ToString();
                _vibrationService.OnTick();
            }
        }

        private bool TryFreePlace()
        {
            foreach (TileMerge tile in _tileMerges)
            {
                if (tile.CheckStatusPlace())
                {
                    Vector3 placeSpawn = tile.transform.position;

                    foreach(var plant in _seedFactory.GetAllPlants())
                    {
                        if(plant.GetLevel() == LevelBuying && plant.gameObject.activeInHierarchy == false)
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