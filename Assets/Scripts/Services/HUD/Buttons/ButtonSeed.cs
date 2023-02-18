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
        
        private const int LevelBuying = 1;
        
        private int _currentPrice = 5;

        private void Start()
        {
            _currentPrice = _saveLoad.ReadPriceSeed();
            _tmp.text = _currentPrice.ToString();
        }

        public void Buy()
        {
            print("we in buy");
            if (_saveLoad.CheckAmountMoney(_currentPrice) && TryFreePlace())
            {
                print("we in if");
                _currentPrice++;
                _saveLoad.SaveNewPriceSeed(_currentPrice);
                _saveLoad.BuySeed(_currentPrice);
                _tmp.text = _currentPrice.ToString();
            }
        }

        private bool TryFreePlace()
        {
            print("enter 1");
            foreach (TileMerge tile in _tileMerges)
            {
                print("enter 2");
                if (tile.CheckStatusPlace())
                {
                    print("enter 3");
                    Vector3 placeSpawn = tile.transform.position;

                    foreach(var plant in _seedFactory.GetAllPlants())
                    {
                        print("enter 4");
                        if(plant.GetLevel() == LevelBuying && plant.gameObject.activeInHierarchy == false)
                        {
                            print("enter 5");
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