using System.Collections.Generic;
using System.Linq;
using Field.Plants;
using Infrastructure.Factory;
using UnityEngine;

namespace Field.GardenObserver
{
    public class ObserverTargets : MonoBehaviour
    {
        [SerializeField] private OperatorFactory _factory;

        private const int LevelBronzeSeed = 1;
        private const int LevelGoldSeed = 5;
        private const int LevelEpicSeed = 9;
        
        protected readonly List<Vegetation> PointsCollect = new List<Vegetation>();

        private void Awake() => 
            Init();

        private void Update() => 
            CustomQueue();

        private void CustomQueue()
        {
            foreach (var vegetation in PointsCollect
                         .Where(vegetation => 
                             vegetation.IsRipe() == false))
            {
                PointsCollect.Remove(vegetation);
                PointsCollect.Add(vegetation);
                return;
            }
        }

        private void Init()
        {
            foreach (var vegetation in _factory.GetAllPlants()
                         .Where(vegetation => 
                             vegetation.GetLevel() != LevelBronzeSeed
                         && vegetation.GetLevel() != LevelGoldSeed 
                         && vegetation.GetLevel() != LevelEpicSeed))
            {
                PointsCollect.Add(vegetation);
            }
        }
    }
}