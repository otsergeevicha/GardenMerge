using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Services.HUD.Canvases.Gift
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

    public class CanvasGiftUp : MonoBehaviour
    {
        [SerializeField] private CanvasGift _canvasGift;

        [SerializeField] private Image _icon;

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

        private Dictionary<int, GiftCard> _cards;
        
        public void ShowResult(int level)
        {
            Init();
            _icon.sprite = _cards[level].IconVegetation;

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
            _cards = new Dictionary<int, GiftCard>()
            {
                [(int)CardType.Coins] = new(_coin),

                [(int)CardType.SeedBronze] = new(_imageSeedBronze),
                [(int)CardType.FlowerBronze] = new(_imageFlowerBronze),
                [(int)CardType.ShrubBronze] = new(_imageShrubBronze),
                [(int)CardType.TreeBronze] = new(_imageTreeBronze),

                [(int)CardType.SeedGold] = new(_imageSeedGold),
                [(int)CardType.FlowerGold] = new(_imageFlowerGold),
                [(int)CardType.ShrubGold] = new(_imageShrubGold),
                [(int)CardType.TreeGold] = new(_imageTreeGold),

                [(int)CardType.SeedEpic] = new(_imageSeedEpic),
                [(int)CardType.FlowerEpic] = new(_imageFlowerEpic),
                [(int)CardType.ShrubEpic] = new(_imageShrubEpic),
                [(int)CardType.TreeEpic] = new(_imageTreeEpic)
            };
        }
    }
}