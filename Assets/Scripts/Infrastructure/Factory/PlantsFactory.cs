using System.Collections.Generic;
using Field.Plants;
using Services.Factory;
using UnityEngine;

namespace Infrastructure.Factory
{
    public abstract class PlantsFactory : MonoBehaviour, IServicePlantsFactory
    {
        public static List<Vegetation> Plants = new List<Vegetation>();

        public abstract void Init();
        
        public List<Vegetation> GetAllPlants() => 
            Plants;
    }
}