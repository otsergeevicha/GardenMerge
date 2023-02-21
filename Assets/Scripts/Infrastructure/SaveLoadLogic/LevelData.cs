using System;
using UnityEngine;

namespace Infrastructure.SaveLoadLogic
{
    [Serializable]
    public class LevelData
    {
        public int LevelVegetation;
        public Vector3 PositionVegetation;

        public LevelData(int levelVegetation, Vector3 positionVegetation)
        {
            LevelVegetation = levelVegetation;
            PositionVegetation = positionVegetation;
        }
    }
}