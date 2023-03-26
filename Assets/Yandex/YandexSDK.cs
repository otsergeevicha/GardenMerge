using System;
using System.Collections;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Yandex
{
    public class YandexSDK : MonoBehaviour
    {
        [DllImport("__Internal")] private static extern void GetPlayerData();

        private void Start()
        {
            print("здесь создать вызов авторизации - GetPlayerData()");
        }
    }
    
    public class PlayerData : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private RawImage _photo;
        
        private Coroutine _coroutine;

        private void OnDisable() => 
            StopCoroutine(_coroutine);

        public void SetName(string name) => 
            _nameText.text = name;

        public void SetPhoto(string url) => 
            _coroutine = StartCoroutine(DownloadImage(url));

        private IEnumerator DownloadImage(string mediaUrl)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaUrl);
            yield return request.SendWebRequest();

            if (request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
                Debug.Log(request.error);
            else
                _photo.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
    }
}