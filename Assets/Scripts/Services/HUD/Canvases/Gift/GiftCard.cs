using System;
using UnityEngine;

namespace Services.HUD.Canvases.Gift
{
    [Serializable]
    public class GiftCard
    {
        public Sprite IconVegetation;

        public GiftCard(Sprite iconVegetation) => 
            IconVegetation = iconVegetation;
    }
}