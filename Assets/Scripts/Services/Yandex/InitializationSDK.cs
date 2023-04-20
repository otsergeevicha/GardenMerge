using System;
using System.Collections;
using Agava.YandexGames;
using GameAnalyticsSDK;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services.Yandex
{
    public class InitializationSDK : MonoBehaviour
    {
        private const int IndexMainScene = 1;

        private const string Key = "Key";

        private void Start()
        {
            GameAnalytics.Initialize();
            
            StartCoroutine(InitSDK());
        }

        private IEnumerator InitSDK()
        {
            while (!YandexGamesSdk.IsInitialized)
                yield return YandexGamesSdk.Initialize();
            
            yield return new WaitForSeconds(1f);
            
            if (PlayerAccount.IsAuthorized)
                PlayerAccount.GetPlayerData(OnSuccessCallback);

            if (PlayerAccount.IsAuthorized == false)
            {
                GameAnalytics.NewDesignEvent($"Player:Authorization:NoAuthorization");
                SceneManager.LoadScene(IndexMainScene);
            }
        }


        
        private void OnSuccessCallback(string data)
        {
            GameAnalytics.NewDesignEvent($"Player:Authorization:Success");

            PlayerPrefs.SetString(Key, data);
            PlayerPrefs.Save();

            SceneManager.LoadScene(IndexMainScene);
        }
    }
}