using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.SaveLoadLogic;
using Services.Merge;
using UnityEngine;

namespace Services.HUD.Canvases.AlmanacLogic
{
    public class AlmanacModule : MonoBehaviour
    {
        [SerializeField] private List<AlmanacType> _almanac = new();
        [SerializeField] private Merging _merging;
        [SerializeField] private SaveLoad _saveLoad;

        private readonly float _maxScale = 120f;
        private readonly float _defaultScale = 55f;
        
        private void OnEnable()
        {
            _merging.Merged += SetCountMerge;
            UpdateInfo();
        }

        private void OnDisable()
        {
            _saveLoad.SaveAlmanac();
            _merging.Merged -= SetCountMerge;
        }

        public List<AlmanacType> GetAlmanac() =>
            _almanac;

        public void IncreaseTotalReceivedCoins(int priceCollect, int levelVegetation)
        {
            AlmanacType almanac = GetCurrentVegetationView(levelVegetation);

            if (almanac != null) 
                almanac.IncreaseTotalReceivedCoins(priceCollect);
            
            _saveLoad.SaveAlmanac();
        }

        private void SetCountMerge(int levelVegetationMerge)
        {
            AlmanacType almanac = GetCurrentVegetationView(levelVegetationMerge);

            if (almanac != null)
            {
                UpdateInfo();
                almanac.SetVisible(true);
                Selected(ConverterLevel(levelVegetationMerge));
                almanac.IncreaseCountMerge();
            }
            
            _saveLoad.SaveAlmanac();
        }

        private AlmanacType GetCurrentVegetationView(int levelVegetationMerge)
        {
            return _almanac.FirstOrDefault(almanac =>
                almanac.LevelVegetation == ConverterLevel(levelVegetationMerge));
        }

        private int ConverterLevel(int workingLevel)
        {
            return workingLevel switch
            {
                (int)WorkingLevelVegetation.FlowerBronze => 
                    (int)LevelViewVegetation.FlowerBronze,
                (int)WorkingLevelVegetation.ShrubBronze =>
                    (int)LevelViewVegetation.ShrubBronze,
                (int)WorkingLevelVegetation.TreeBronze => 
                    (int)LevelViewVegetation.TreeBronze,
                (int)WorkingLevelVegetation.FlowerGold => 
                    (int)LevelViewVegetation.FlowerGold,
                (int)WorkingLevelVegetation.ShrubGold => 
                    (int)LevelViewVegetation.ShrubGold,
                (int)WorkingLevelVegetation.TreeGold => 
                    (int)LevelViewVegetation.TreeGold,
                (int)WorkingLevelVegetation.FlowerEpic => 
                    (int)LevelViewVegetation.FlowerEpic,
                (int)WorkingLevelVegetation.ShrubEpic => 
                    (int)LevelViewVegetation.ShrubEpic,
                (int)WorkingLevelVegetation.TreeEpic => 
                    (int)LevelViewVegetation.TreeEpic,
                _ => 0
            };
        }

        public void UpdateInfo()
        {
            foreach (AlmanacDataType saveType in _saveLoad.ReadAlmanac())
            {
                foreach (AlmanacType sceneType in _almanac.Where(sceneType =>
                             saveType.LevelVegetation == sceneType.LevelVegetation))
                {
                    sceneType.SetVisible(saveType.IsVisibleImage);
                    sceneType.SetCountMerge(saveType.CountMerge);
                    sceneType.SetTotalCountCoins(saveType.TotalCountCoins);
                }
            }
        }

        public void Selected(int levelVegetation)
        {
            foreach (AlmanacType type in _almanac)
            {
                if (type.LevelVegetation == levelVegetation)
                {
                    type.ChangeSize(new Vector2(_maxScale, _maxScale));
                    continue;
                }

                type.ChangeSize(new Vector2(_defaultScale, _defaultScale));
            }
        }

        public void FirstSelection()
        {
            var level = _saveLoad.ReadAlmanac().LastOrDefault(typeAlmanac => typeAlmanac.IsVisibleImage);

            if (level != null)
                Selected(level.LevelVegetation);
        }
    }
}