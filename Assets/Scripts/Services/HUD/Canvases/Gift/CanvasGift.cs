using System.Collections;
using System.Linq;
using Field.Tiles.Move;
using Infrastructure.Factory;
using Infrastructure.SaveLoadLogic;
using Services.HUD.Buttons;
using Services.HUD.Canvases.Gift;
using UnityEngine;

enum GiftType
{
    SeedBronze = 1,
    SeedGold = 5,
    SeedEpic = 9,
    FlowerBronze = 2,
    ShrubBronze = 3,
    TreeBronze = 4
}

namespace Services.HUD.Canvases
{
    public class CanvasGift : MonoBehaviour
    {
        [SerializeField] private ButtonDailySpin _dailySpin;
        [SerializeField] private RectTransform _roulette;

        [SerializeField] private TileMerge[] _tileMerges;
        [SerializeField] private OperatorFactory _plantsFactory;
        [SerializeField] private SaveLoad _saveLoad;
        
        [SerializeField] private CanvasHud _canvasHud;
        [SerializeField] private CanvasGiftUp _canvasGiftUp;

        private const int GiftMoney = 50;

        private int _randomValue;
        private int _finalAngle;
        private float _timeInterval;
        
        private Coroutine _coroutine;

        public void Spin()
        {
            if (_dailySpin.CanSpin())
                Twist();
        }

        public void Close()
        {
            Time.timeScale = 1;
            _canvasHud.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        private void Twist()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }

            Time.timeScale = 1;
            
            _coroutine = StartCoroutine(RotationRoulette());
        }

        private void Gift(int levelSpawn)
        {
            foreach (TileMerge tile in _tileMerges)
            {
                if (tile.CheckStatusPlace())
                {
                    Vector3 placeSpawn = tile.transform.position;

                    foreach (var plant in _plantsFactory.GetAllPlants()
                                 .Where(plant => 
                                     plant.GetLevel() == levelSpawn 
                                     && plant.gameObject.activeInHierarchy == false))
                    {
                        plant.gameObject.transform.position = placeSpawn;
                        plant.gameObject.SetActive(true);
                        _canvasGiftUp.ShowResult(levelSpawn);
                        return;
                    }
                }
            }
            
            
        }

        private IEnumerator RotationRoulette()
        {
            _randomValue = Random.Range(20, 30);
            _timeInterval = .01f;

            float zAngle = _roulette.rotation.z;

            for (int i = 0; i < _randomValue; i++)
            {
                _roulette.Rotate(0, 0, Mathf.Lerp(zAngle, 22.5f, .8f));

                if (i > Mathf.RoundToInt(_randomValue * .55f))
                    _timeInterval *= .15f;
                
                yield return new WaitForSeconds(_timeInterval);
            }
            
            _finalAngle = Mathf.RoundToInt(_roulette.eulerAngles.z / 45);
            
            switch (_finalAngle)
            {
                case 0:
                    Gift((int)GiftType.TreeBronze);
                    break;
                case 1:
                    _saveLoad.ApplyMoney(GiftMoney);
                    _canvasGiftUp.ShowResult(0);
                    break;
                case 2:
                    Twist();
                    break;
                case 3:
                    Gift((int)GiftType.SeedBronze);
                    break;
                case 4:
                    Gift((int)GiftType.SeedGold);
                    break;
                case 5:
                    Gift((int)GiftType.SeedEpic);
                    break;
                case 6:
                    Gift((int)GiftType.FlowerBronze);
                    break;
                case 7:
                    Gift((int)GiftType.ShrubBronze);
                    break;
            }
        }
    }
}