using System;
using UnityEngine;

namespace Services.HUD.Canvases.GiftCards
{
    [Serializable]
    public class MergeCard
    {
        public Sprite IconVegetation;
        public string NameVegetation;

        public MergeCard(Sprite iconVegetation, string nameVegetation)
        {
            IconVegetation = iconVegetation;
            NameVegetation = nameVegetation;
        }
    }
}