using GameAnalyticsSDK;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services.Yandex
{
    public class InitializationSDK : MonoBehaviour
    {
        private const int IndexMainScene = 1;

        private void Start()
        {
            GameAnalytics.Initialize();
            SceneManager.LoadScene(IndexMainScene);
        }
    }
}