using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Services.HUD.Canvases
{
    public class CanvasMerge : MonoBehaviour
    {
        [SerializeField] private CanvasHud _canvasHud;
        
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _result;
        [SerializeField] private TMP_Text _nameVegetation;

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

        private readonly List<MergeCard> _mergeCards = new ();

        private void Start()
        {
            _mergeCards.Add(new MergeCard(1, _imageSeedBronze, "Seed Bronze"));
            _mergeCards.Add(new MergeCard(2, _imageFlowerBronze, "Flower Bronze"));
            _mergeCards.Add(new MergeCard(3, _imageShrubBronze, "Shrub Bronze"));
            _mergeCards.Add(new MergeCard(4, _imageTreeBronze, "Tree Bronze"));
            
            _mergeCards.Add(new MergeCard(5, _imageSeedGold, "Seed Gold"));
            _mergeCards.Add(new MergeCard(6, _imageFlowerGold, "Flower Gold"));
            _mergeCards.Add(new MergeCard(7, _imageShrubGold, "Shrub Gold"));
            _mergeCards.Add(new MergeCard(8, _imageTreeGold, "Tree Gold"));
            
            _mergeCards.Add(new MergeCard(9, _imageSeedEpic, "Seed Epic"));
            _mergeCards.Add(new MergeCard(10, _imageFlowerEpic, "Flower Epic"));
            _mergeCards.Add(new MergeCard(11, _imageShrubEpic, "Shrub Epic"));
            _mergeCards.Add(new MergeCard(12, _imageTreeEpic, "Tree Epic"));
        }

        public void ShowResultMerge(int levelMerge)
        {
            _canvasHud.gameObject.SetActive(false);
            gameObject.SetActive(true);

            foreach (MergeCard card in _mergeCards)
            {
                if (card.LevelVegetation == levelMerge)
                {
                    _icon.sprite = card.IconVegetation;
                    _nameVegetation.text = card.NameVegetation;
                    
                    if (_resultMerges.Length != 0)
                    {
                        _result.text = _resultMerges[Random.Range(0, _resultMerges.Length)];
                    }
                    return;
                }
            }
        }

        public void CloseCanvas()
        {
            _canvasHud.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    [Serializable]
    public class MergeCard
    {
        public int LevelVegetation;
        public Sprite IconVegetation;
        public string NameVegetation;

        public MergeCard(int levelVegetation, Sprite iconVegetation, string nameVegetation)
        {
            LevelVegetation = levelVegetation;
            IconVegetation = iconVegetation;
            NameVegetation = nameVegetation;
        }
    }
}