using Infrastructure.AssetManagement;
using UnityEngine;

namespace Infrastructure
{
    public class Game
    {
        public void Init()
        {
            AssetProvider assetProvider = new AssetProvider();
            assetProvider.Instantiate(AssetPath.InputObserver, Vector3.zero);
        }
    }
}