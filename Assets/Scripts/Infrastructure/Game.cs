using Infrastructure.AssetManagement;
using UnityEngine;

namespace Infrastructure
{
    public class Game : MonoBehaviour
    {
        public void Awake()
        {
            AssetProvider assetProvider = new AssetProvider();
            assetProvider.Instantiate(AssetPath.InputObserver, Vector3.zero);
        }
    }
}
