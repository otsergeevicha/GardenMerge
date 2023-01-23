using System;
using System.Collections.Generic;
using System.Linq;
using Field.Plants;
using UnityEngine;

namespace Field.GardenObserver
{
    public class GardenerBaseTargets : MonoBehaviour
    {
        private Queue<Vegetation> _targetsPlants = new Queue<Vegetation>();
        private bool _isGetFirstTarget = true;

        public event Action OnFirstStep;

        public Vector3 TryGetTarget()
        {
            if(_targetsPlants != null && _targetsPlants
                   .Any(plant =>
                       plant.IsRipe()))
            {
                _targetsPlants.Enqueue(_targetsPlants.Peek());
                return _targetsPlants.Dequeue().transform.position;
            }

            return transform.position;
        }

        public void Add(Vegetation newVegetation)
        {
            _targetsPlants.Enqueue(newVegetation);

            if(_isGetFirstTarget)
            {
                print("first step");
                _isGetFirstTarget = false;
                OnFirstStep?.Invoke();
            }
        }
    }
}