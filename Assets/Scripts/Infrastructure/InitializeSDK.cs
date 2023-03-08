using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure
{
    public class InitializeSDK : MonoBehaviour
    {
        private readonly int _startSceneIndex = 1;
        
        private string _language;

        public string CurrentLanguage => 
            _language; //всегда приходит - en, нижний регистр
    }
}