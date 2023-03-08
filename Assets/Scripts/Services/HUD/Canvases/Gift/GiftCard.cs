using System;
using UnityEngine;

namespace Services.HUD.Canvases.Gift
{
    [Serializable]
    public class GiftCard
    {
        public Sprite IconVegetation;
        public string NameVegetation;

        public GiftCard(Sprite iconVegetation, string nameVegetation)
        {
            IconVegetation = iconVegetation;
            NameVegetation = nameVegetation;
        }
    }
}