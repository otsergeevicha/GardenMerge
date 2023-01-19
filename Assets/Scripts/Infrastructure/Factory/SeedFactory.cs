using System.Collections.Generic;
using Field.Plants;
using Infrastructure.AssetManagement;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class SeedFactory : PlantsFactory
    {
        [SerializeField] private int _capacitySeed;
        
        private AssetProvider _assetProvider = new AssetProvider();

        private void Start() => 
            Init();

        public override void Init()
        {
            for(int i = 0; i < _capacitySeed; i++)
            {
                InstantiateRegistered(AssetPath.BronzeSeed);
                InstantiateRegistered(AssetPath.GoldSeed);
                InstantiateRegistered(AssetPath.EpicTree);
            }
        }

        private void InstantiateRegistered(string typeSeed)
        {
            GameObject vegetation = _assetProvider.Instantiate(typeSeed, Vector3.zero);
            vegetation.gameObject.SetActive(false);
            Plants.Add(vegetation.GetComponent<Vegetation>());
        }
    }
}