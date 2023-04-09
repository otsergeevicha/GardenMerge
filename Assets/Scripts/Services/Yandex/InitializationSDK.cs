using System.Collections;
using Agava.YandexGames;
using Infrastructure.SaveLoadLogic;
using Lean.Localization;
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
            
            if (PlayerAccount.IsAuthorized == false)
                SceneManager.LoadScene(IndexMainScene);
        }

        private void OnSuccessCallback(string data)
        {
            LeanLocalization.SetCurrentLanguageAll(YandexGamesSdk.Environment.i18n.lang);
            
           PlayerPrefs.SetString(Key, data);
           PlayerPrefs.Save();

           SceneManager.LoadScene(IndexMainScene);
        }
    }
}