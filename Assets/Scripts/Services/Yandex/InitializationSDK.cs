using System.Collections;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services.Yandex
{
    public class InitializationSDK : MonoBehaviour
    {
        private const int IndexMainScene = 1;
        
        private void Awake()
        {
            StartCoroutine(InitSDK());
        }

        private IEnumerator InitSDK()
        {
            while (!YandexGamesSdk.IsInitialized)
                yield return YandexGamesSdk.Initialize();

            SceneManager.LoadScene(IndexMainScene);
        }
    }
}