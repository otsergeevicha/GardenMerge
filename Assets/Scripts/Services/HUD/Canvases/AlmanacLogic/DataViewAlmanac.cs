using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Services.HUD.Canvases.AlmanacLogic
{
    enum LevelViewVegetation
    {
        FlowerBronze = 1,
        ShrubBronze = 2,
        TreeBronze = 3,

        FlowerGold = 4,
        ShrubGold = 5,
        TreeGold = 6,

        FlowerEpic = 7,
        ShrubEpic = 8,
        TreeEpic = 9
    }

    public class DataViewAlmanac : MonoBehaviour
    {
        [SerializeField] private Sprite _spriteFlowerBronze;
        [SerializeField] private Sprite _spriteShrubBronze;
        [SerializeField] private Sprite _spriteTreeBronze;

        [SerializeField] private Sprite _spriteFlowerGold;
        [SerializeField] private Sprite _spriteShrubGold;
        [SerializeField] private Sprite _spriteTreeGold;

        [SerializeField] private Sprite _spriteFlowerEpic;
        [SerializeField] private Sprite _spriteShrubEpic;
        [SerializeField] private Sprite _spriteTreeEpic;

        public Sprite GetCurrentSprite(int levelVegetation)
        {
            return levelVegetation switch
            {
                (int)LevelViewVegetation.FlowerBronze =>
                    _spriteFlowerBronze,
                (int)LevelViewVegetation.ShrubBronze =>
                    _spriteShrubBronze,
                (int)LevelViewVegetation.TreeBronze =>
                    _spriteTreeBronze,
                (int)LevelViewVegetation.FlowerGold =>
                    _spriteFlowerGold,
                (int)LevelViewVegetation.ShrubGold =>
                    _spriteShrubGold,
                (int)LevelViewVegetation.TreeGold =>
                    _spriteTreeGold,
                (int)LevelViewVegetation.FlowerEpic =>
                    _spriteFlowerEpic,
                (int)LevelViewVegetation.ShrubEpic =>
                    _spriteShrubEpic,
                (int)LevelViewVegetation.TreeEpic =>
                    _spriteTreeEpic,
                _ => null
            };
        }
        
        [SerializeField] private TMP_Text _nameFlowerBronze;
        [SerializeField] private TMP_Text _nameShrubBronze;
        [SerializeField] private TMP_Text _nameTreeBronze;

        [SerializeField] private TMP_Text _nameFlowerGold;
        [SerializeField] private TMP_Text _nameShrubGold;
        [SerializeField] private TMP_Text _nameTreeGold;

        [SerializeField] private TMP_Text _nameFlowerEpic;
        [SerializeField] private TMP_Text _nameShrubEpic;
        [SerializeField] private TMP_Text _nameTreeEpic;

        public TMP_Text GetCurrentName(int levelVegetation)
        {
            return levelVegetation switch
            {
                (int)LevelViewVegetation.FlowerBronze =>
                    _nameFlowerBronze,
                (int)LevelViewVegetation.ShrubBronze =>
                    _nameShrubBronze,
                (int)LevelViewVegetation.TreeBronze =>
                    _nameTreeBronze,
                (int)LevelViewVegetation.FlowerGold =>
                    _nameFlowerGold,
                (int)LevelViewVegetation.ShrubGold =>
                    _nameShrubGold,
                (int)LevelViewVegetation.TreeGold =>
                    _nameTreeGold,
                (int)LevelViewVegetation.FlowerEpic =>
                    _nameFlowerEpic,
                (int)LevelViewVegetation.ShrubEpic =>
                    _nameShrubEpic,
                (int)LevelViewVegetation.TreeEpic =>
                    _nameTreeEpic,
                _ => null
            };
        }
        
        [SerializeField] private Sprite _spriteRankBronze;
        [SerializeField] private Sprite _spriteRankGold;
        [SerializeField] private Sprite _spriteRankEpic;
        
        public Sprite GetRankSprite(int levelVegetation)
        {
            return levelVegetation switch
            {
                (int)LevelViewVegetation.FlowerBronze =>
                    _spriteRankBronze,
                (int)LevelViewVegetation.ShrubBronze =>
                    _spriteRankBronze,
                (int)LevelViewVegetation.TreeBronze =>
                    _spriteRankBronze,
                (int)LevelViewVegetation.FlowerGold =>
                    _spriteRankGold,
                (int)LevelViewVegetation.ShrubGold =>
                    _spriteRankGold,
                (int)LevelViewVegetation.TreeGold =>
                    _spriteRankGold,
                (int)LevelViewVegetation.FlowerEpic =>
                    _spriteRankEpic,
                (int)LevelViewVegetation.ShrubEpic =>
                    _spriteRankEpic,
                (int)LevelViewVegetation.TreeEpic =>
                    _spriteRankEpic,
                _ => null
            };
        }
    }
}