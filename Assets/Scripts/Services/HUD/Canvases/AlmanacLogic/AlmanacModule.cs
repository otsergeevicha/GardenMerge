using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.SaveLoadLogic;
using UnityEngine;

namespace Services.HUD.Canvases.AlmanacLogic
{
    public class AlmanacModule : MonoBehaviour
    {
        [SerializeField] private List<AlmanacType> _almanac = new();

        [SerializeField] private SaveLoad _saveLoad;

        private readonly float _maxScale = 120f;
        private readonly float _defaultScale = 55f;

        private void Start()
        {
            Init();
        }

        private void OnDisable() => 
            _saveLoad.SaveAlmanac();

        private void Init()
        {
            foreach (AlmanacType saveType in _saveLoad.ReadAlmanac())
            {
                foreach (AlmanacType sceneType in _almanac.Where(sceneType =>
                             saveType.LevelVegetation == sceneType.LevelVegetation))
                {
                    sceneType.ChangeSize(saveType.RectTransform.sizeDelta);
                    sceneType.ChangeImageContainer(saveType.ImageContainer);
                    sceneType.VisibleImage(saveType.IsVisibleImage);
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

        public List<AlmanacType> GetAlmanac() =>
            _almanac;
    }
}