using System.Collections.Generic;
using Services.HUD.Canvases.GiftCards;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Services.HUD.Canvases
{
    enum CardType
    {
        Coins = 0,

        SeedBronze = 1,
        FlowerBronze = 2,
        ShrubBronze = 3,
        TreeBronze = 4,

        SeedGold = 5,
        FlowerGold = 6,
        ShrubGold = 7,
        TreeGold = 8,

        SeedEpic = 9,
        FlowerEpic = 10,
        ShrubEpic = 11,
        TreeEpic = 12,
    }

    public class CanvasMerge : MonoBehaviour
    {
        [SerializeField] private CanvasGift _canvasGift;

        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _result;
        [SerializeField] private TMP_Text _nameVegetation;

        [SerializeField] private Sprite _coin;

        [SerializeField] private Sprite _imageSeedBronze;
        [SerializeField] private Sprite _imageSeedGold;
        [SerializeField] private Sprite _imageSeedEpic;

        [SerializeField] private Sprite _imageFlowerBronze;
        [SerializeField] private Sprite _imageShrubBronze;
        [SerializeField] private Sprite _imageTreeBronze;

        [SerializeField] private Sprite _imageFlowerGold;
        [SerializeField] private Sprite _imageShrubGold;
        [SerializeField] private Sprite _imageTreeGold;

        [SerializeField] private Sprite _imageFlowerEpic;
        [SerializeField] private Sprite _imageShrubEpic;
        [SerializeField] private Sprite _imageTreeEpic;

        [SerializeField] private string[] _resultMerges;

        private Dictionary<int, MergeCard> _cards;

        public void ShowResult(int level)
        {
            _icon.sprite = _cards[level].IconVegetation;
            _nameVegetation.text = _cards[level].NameVegetation;

            if (_resultMerges.Length != 0)
                _result.text = _resultMerges[Random.Range(0, _resultMerges.Length)];

            _canvasGift.gameObject.SetActive(false);
            gameObject.SetActive(true);

            Time.timeScale = 0;
        }

        public void CloseCanvas()
        {
            gameObject.SetActive(false);
            _canvasGift.gameObject.SetActive(true);

            Time.timeScale = 1;
        }

        public void Init()
        {
            _cards = new Dictionary<int, MergeCard>()
            {
                [(int)CardType.Coins] = new(_coin, "50 COINS"),

                [(int)CardType.SeedBronze] = new(_imageSeedBronze, "Seed Bronze"),
                [(int)CardType.FlowerBronze] = new(_imageFlowerBronze, "Flower Bronze"),
                [(int)CardType.ShrubBronze] = new(_imageShrubBronze, "Shrub Bronze"),
                [(int)CardType.TreeBronze] = new(_imageTreeBronze, "Tree Bronze"),

                [(int)CardType.SeedGold] = new(_imageSeedGold, "Seed Gold"),
                [(int)CardType.FlowerGold] = new(_imageFlowerGold, "Flower Gold"),
                [(int)CardType.ShrubGold] = new(_imageShrubGold, "Shrub Gold"),
                [(int)CardType.TreeGold] = new(_imageTreeGold, "Tree Gold"),

                [(int)CardType.SeedEpic] = new(_imageSeedEpic, "Seed Epic"),
                [(int)CardType.FlowerEpic] = new(_imageFlowerEpic, "Flower Epic"),
                [(int)CardType.ShrubEpic] = new(_imageShrubEpic, "Shrub Epic"),
                [(int)CardType.TreeEpic] = new(_imageTreeEpic, "Tree Epic")
            };
        }
    }
}