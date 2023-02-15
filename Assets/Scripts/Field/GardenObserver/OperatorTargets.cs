using System.Linq;
using Field.GardenerLogic;
using Field.Plants;
using UnityEngine;

namespace Field.GardenObserver
{
    [RequireComponent(typeof(Gardener))]
    public class OperatorTargets : ObserverTargets
    {
        public Vegetation TryGetTarget()
        {
            foreach (var vegetation in PointsCollect
                         .Where(vegetation => 
                             vegetation.IsRipe()))
            {
                return vegetation;
            }

            return null;
        }
    }
}