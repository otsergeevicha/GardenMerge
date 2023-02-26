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

        [SerializeField] private TMP_Text _name50Coins;
        
        [SerializeField] private TMP_Text _nameSeedBronze;
        [SerializeField] private TMP_Text _nameFlowerBronze;
        [SerializeField] private TMP_Text _nameShrubBronze;
        [SerializeField] private TMP_Text _nameTreeBronze;
        
        [SerializeField] private TMP_Text _nameSeedGold;
        [SerializeField] private TMP_Text _nameFlowerGold;
        [SerializeField] private TMP_Text _nameShrubGold;
        [SerializeField] private TMP_Text _nameTreeGold;
        
        [SerializeField] private TMP_Text _nameSeedEpic;
        [SerializeField] private TMP_Text _nameFlowerEpic;
        [SerializeField] private TMP_Text _nameShrubEpic;
        [SerializeField] private TMP_Text _nameTreeEpic;

        [SerializeField] private TMP_Text[] _resultMerges;

        private Dictionary<int, MergeCard> _cards;

        public void ShowResult(int level)
        {
            _icon.sprite = _cards[level].IconVegetation;
            _nameVegetation.text = _cards[level].NameVegetation;

            if (_resultMerges.Length != 0)
                _result = _resultMerges[Random.Range(0, _resultMerges.Length)];

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
                [(int)CardType.Coins] = new(_coin, _name50Coins.text),

                [(int)CardType.SeedBronze] = new(_imageSeedBronze, _nameSeedBronze.text),
                [(int)CardType.FlowerBronze] = new(_imageFlowerBronze, _nameFlowerBronze.text),
                [(int)CardType.ShrubBronze] = new(_imageShrubBronze, _nameShrubBronze.text),
                [(int)CardType.TreeBronze] = new(_imageTreeBronze, _nameTreeBronze.text),

                [(int)CardType.SeedGold] = new(_imageSeedGold, _nameSeedGold.text),
                [(int)CardType.FlowerGold] = new(_imageFlowerGold, _nameFlowerGold.text),
                [(int)CardType.ShrubGold] = new(_imageShrubGold, _nameShrubGold.text),
                [(int)CardType.TreeGold] = new(_imageTreeGold, _nameTreeGold.text),

                [(int)CardType.SeedEpic] = new(_imageSeedEpic, _nameSeedEpic.text),
                [(int)CardType.FlowerEpic] = new(_imageFlowerEpic, _nameFlowerEpic.text),
                [(int)CardType.ShrubEpic] = new(_imageShrubEpic, _nameShrubEpic.text),
                [(int)CardType.TreeEpic] = new(_imageTreeEpic, _nameTreeEpic.text)
            };
        }
    }
}