using Field.GardenerLogic;
using Field.Plants;
using UnityEngine;

namespace Field.GardenObserver
{
    [RequireComponent(typeof(Gardener))]
    public class OperatorTargets : ObserverTargets
    {
        public bool IsHavePath =>
            CheckGetGoal();

        public Vector3 TryGetTarget()
        {
            if (CheckGetGoal())
            {
                Vegetation vegetation = PointsCollect.Dequeue();
                PointsCollect.Enqueue(vegetation);
                return vegetation.transform.position;
            }

            return transform.position;
        }

        private bool CheckGetGoal()
        {
            
                Vegetation vegetation = PointsCollect.Peek();
            
                if (vegetation.IsRipe())
                {
                    print("2");
                    return true;
                }
                
                return false;
        }
    }
}