using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services.Yandex
{
    public class InitializationSDK : MonoBehaviour
    {
        private const int IndexMainScene = 1;
        
        private void Awake() =>
            SceneManager.LoadScene(IndexMainScene);
    }
}