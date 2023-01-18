using UnityEngine;

namespace Infrastructure.AssetManagement
{
    public interface IAssets
    {
        GameObject Instantiate(string path, Vector3 at);
    }
}