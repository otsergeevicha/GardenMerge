using System.Collections.Generic;
using Field.Plants;
using Infrastructure.AssetManagement;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class EpicEntityFactory : PlantsFactory
    {
        [SerializeField] private int _capacity;

        private AssetProvider _assetProvider = new AssetProvider();

        private void Start() => 
            Init();
        
        public override void Init()
        {
            for(int i = 0; i < _capacity; i++)
            {
                Plants.Add(InstantiateRegistered(AssetPath.EpicFlower)
                    .GetComponent<Vegetation>());
                Plants.Add(InstantiateRegistered(AssetPath.EpicShrub)
                    .GetComponent<Vegetation>());
                Plants.Add(InstantiateRegistered(AssetPath.EpicTree)
                    .GetComponent<Vegetation>());
            }
        }
        
        private GameObject InstantiateRegistered(string typeSeed)
        {
            GameObject vegetation = _assetProvider.Instantiate(typeSeed, Vector3.zero);
            vegetation.gameObject.SetActive(false);
            return vegetation;
        }
    }
}