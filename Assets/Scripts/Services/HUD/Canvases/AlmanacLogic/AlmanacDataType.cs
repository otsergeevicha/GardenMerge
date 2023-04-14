using System;

namespace Services.HUD.Canvases.AlmanacLogic
{
    [Serializable]
    public class AlmanacDataType
    {
        public int LevelVegetation;

        public bool IsVisibleImage;
        
        public int CountMerge;
        public int TotalCountCoins;
        
        public AlmanacDataType(int levelVegetation, bool isVisibleImage, int countMerge, int totalCountCoins)
        {
            LevelVegetation = levelVegetation;
            IsVisibleImage = isVisibleImage;
            CountMerge = countMerge;
            TotalCountCoins = totalCountCoins;
        }
    }
}