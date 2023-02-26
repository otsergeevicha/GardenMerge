using System.Collections;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure
{
    public class InitializeSDK : MonoBehaviour
    {
        private readonly int _startSceneIndex = 1;
        
        private string _language;

        public string CurrentLanguage => _language;
        
        private void Awake() => 
            StartCoroutine(Init());

        private IEnumerator Init()
        {
            while (YandexGamesSdk.IsInitialized == false)
                yield return YandexGamesSdk.Initialize();

            _language = YandexGamesSdk.Environment.i18n.lang;

            SceneManager.LoadScene(_startSceneIndex);
        }
    }
}