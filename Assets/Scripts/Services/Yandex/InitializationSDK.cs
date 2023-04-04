using System.Collections;
using Agava.YandexGames;
using Infrastructure.SaveLoadLogic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services.Yandex
{
    public class InitializationSDK : MonoBehaviour
    {
        private const int IndexMainScene = 1;

        private const string Key = "Key";

        private void Awake() =>
            StartCoroutine(InitSDK());

        private IEnumerator InitSDK()
        {
            while (!YandexGamesSdk.IsInitialized)
                yield return YandexGamesSdk.Initialize();

            YandexGamesSdk.CallbackLogging = true;

            if (PlayerAccount.IsAuthorized) 
                PlayerAccount.GetPlayerData(OnSuccessCallback);
        }

        private void OnSuccessCallback(string data)
        {
            PlayerPrefs.SetString(Key, data);
            PlayerPrefs.Save();

            SceneManager.LoadScene(IndexMainScene);
        }
    }
}