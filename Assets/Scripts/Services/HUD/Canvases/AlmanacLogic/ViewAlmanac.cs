using System.Linq;
using Field.Plants;
using Infrastructure.Factory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Services.HUD.Canvases.AlmanacLogic
{
    enum WorkingLevelVegetation
    {
        FlowerBronze = 2,
        ShrubBronze = 3,
        TreeBronze = 4,

        FlowerGold = 6,
        ShrubGold = 7,
        TreeGold = 8,

        FlowerEpic = 10,
        ShrubEpic = 11,
        TreeEpic = 12
    }

    public class ViewAlmanac : MonoBehaviour
    {
        [SerializeField] private DataViewAlmanac _dataAlmanac;
        [SerializeField] private OperatorFactory _factory;

        [SerializeField] private Image _iconVegetation;
        [SerializeField] private Image _iconRank;

        [SerializeField] private TextMeshProUGUI _textLevelInfo;

        [SerializeField] private TMP_Text _name;

        [SerializeField] private TextMeshProUGUI _expMerge;
        [SerializeField] private Image _iconCup;

        [SerializeField] private TextMeshProUGUI _textTimeCollect;
        [SerializeField] private TextMeshProUGUI _textFloweringPeriod;
        [SerializeField] private TextMeshProUGUI _textAmountReward;
        [SerializeField] private TextMeshProUGUI _textTotalAmountMerge;
        [SerializeField] private TextMeshProUGUI _textTotalCoinsReceived;

        [SerializeField] private Slider _sliderExp;

        public void Show(int levelVegetation, int countMerge, int totalCountMoney)
        {
            _iconVegetation.sprite = _dataAlmanac.GetCurrentSprite(levelVegetation);
            _iconRank.sprite = _dataAlmanac.GetRankSprite(levelVegetation);

            _textLevelInfo.text = levelVegetation.ToString();
            _name.text = _dataAlmanac.GetCurrentName(levelVegetation).text;

            _expMerge.text = $"{GetAmountExp(countMerge)}/50";
            _sliderExp.value = GetAmountExp(countMerge);

            _textTotalAmountMerge.text = countMerge.ToString();
            _textTotalCoinsReceived.text = totalCountMoney.ToString();
            
            SetDataFactory(levelVegetation);
        }

        private void SetInfo(int workingLevel)
        {
            Vegetation plant = _factory.GetAllPlants()
                .FirstOrDefault(plants => 
                    plants.GetLevel() == workingLevel);

            if (plant != null)
            {
                _textTimeCollect.text = plant.GetTimeCollect().ToString();
                _textFloweringPeriod.text = plant.GetFloweringPeriod().ToString();
               _textAmountReward.text = plant.PriceCollect().ToString();
            }
        }

        private void SetDataFactory(int levelVegetation)
        {
            switch (levelVegetation)
            {
                case
                    (int)LevelViewVegetation.FlowerBronze:
                    SetInfo((int)WorkingLevelVegetation.FlowerBronze);
                    break;
                case
                    (int)LevelViewVegetation.ShrubBronze:
                    SetInfo((int)WorkingLevelVegetation.ShrubBronze);
                    break;
                case
                    (int)LevelViewVegetation.TreeBronze:
                    SetInfo((int)WorkingLevelVegetation.TreeBronze);
                    break;
                case
                    (int)LevelViewVegetation.FlowerGold:
                    SetInfo((int)WorkingLevelVegetation.FlowerGold);
                    break;
                case
                    (int)LevelViewVegetation.ShrubGold:
                    SetInfo((int)WorkingLevelVegetation.ShrubGold);
                    break;
                case
                    (int)LevelViewVegetation.TreeGold:
                    SetInfo((int)WorkingLevelVegetation.TreeGold);
                    break;
                case
                    (int)LevelViewVegetation.FlowerEpic:
                    SetInfo((int)WorkingLevelVegetation.FlowerEpic);
                    break;
                case
                    (int)LevelViewVegetation.ShrubEpic:
                    SetInfo((int)WorkingLevelVegetation.ShrubEpic);
                    break;
                case
                    (int)LevelViewVegetation.TreeEpic:
                    SetInfo((int)WorkingLevelVegetation.TreeEpic);
                    break;
            }
        }

        private int GetAmountExp(int countMerge)
        {
            if (countMerge >= 50)
            {
                _iconCup.gameObject.SetActive(true);
                countMerge = 50;
                return countMerge;
            }

            _iconCup.gameObject.SetActive(false);
            return countMerge;
        }
    }
}