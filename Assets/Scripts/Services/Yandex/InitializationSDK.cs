using System.Collections;
using DungeonGames.VKGames;
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

            StartCoroutine(InitSDK());
        }

        private IEnumerator InitSDK()
        {
            while (!VKGamesSdk.Initialized)
                yield return VKGamesSdk.Initialize();

            SceneManager.LoadScene(IndexMainScene);
        }
    }
}