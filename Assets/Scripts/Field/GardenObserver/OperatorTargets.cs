using System.Linq;
using Field.GardenerLogic;
using UnityEngine;

namespace Field.GardenObserver
{
    [RequireComponent(typeof(Gardener))]
    public class OperatorTargets : ObserverTargets
    {
        public Vector3 TryGetTarget()
        {
            foreach (var vegetation in PointsCollect
                         .Where(vegetation => 
                             vegetation.IsRipe()))
            {
                return vegetation.transform.position;
            }

            return transform.position;
        }
    }
}