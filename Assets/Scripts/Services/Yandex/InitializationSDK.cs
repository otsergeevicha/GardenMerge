using System.Collections;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services.Yandex
{
    public class InitializationSDK : MonoBehaviour
    {
        private const int IndexMainScene = 1;
        
        private void Awake() => 
            StartCoroutine(InitSDK());

        private void OnOpenCallback() => 
            throw new System.NotImplementedException();

        private void OnErrorCallback(string obj) => 
            SceneManager.LoadScene(IndexMainScene);

        private void OnCloseCallback(bool obj) => 
            SceneManager.LoadScene(IndexMainScene);

        private IEnumerator InitSDK()
        {
            while (!YandexGamesSdk.IsInitialized)
                yield return YandexGamesSdk.Initialize();

            InterstitialAd.Show(OnOpenCallback, OnCloseCallback, OnErrorCallback);
        }
    }
}