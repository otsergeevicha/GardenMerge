using Field.Plants;
using Infrastructure.AssetManagement;
using Services.Move;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class SeedFactory : PlantsFactory
    {
        [SerializeField] private int _capacitySeed;
        
        private AssetProvider _assetProvider = new AssetProvider();

        private void Awake()
        {
            Init();
        }

        public override void Init()
        {
            for(int i = 0; i < _capacitySeed; i++)
            {
                InstantiateRegistered(AssetPath.BronzeSeed);
                InstantiateRegistered(AssetPath.GoldSeed);
                InstantiateRegistered(AssetPath.EpicSeed);
            }
        }

        private void InstantiateRegistered(string typeSeed)
        {
            GameObject vegetation = _assetProvider.Instantiate(typeSeed, Vector3.zero);
            vegetation.gameObject.SetActive(false);
            vegetation.GetComponent<DraggingOptionVegetation>().Init(Merging);
            Plants.Add(vegetation.GetComponent<Vegetation>());
        }
    }
}