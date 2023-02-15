using System.Collections.Generic;
using Field.Plants;
using Services.Factory;
using Services.Merge;
using UnityEngine;

namespace Infrastructure.Factory
{
    public abstract class PlantsFactory : MonoBehaviour, IServicePlantsFactory
    {
        [SerializeField] protected Merging Merging;
        
        public static readonly List<Vegetation> Plants = new List<Vegetation>();

        public abstract void Init();
        
        public List<Vegetation> GetAllPlants() => 
            Plants;
    }
}