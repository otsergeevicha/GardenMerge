using System;
using Agava.YandexGames;
using UnityEngine;

namespace Services.HUD.Canvases
{
    public class CanvasMenu : MonoBehaviour
    {
        [SerializeField] private CanvasSetting _canvasSetting;

        private void FixedUpdate()
        {
            if (isActiveAndEnabled == false)
                return;
            
            Time.timeScale = 0;
        }

        public void ContinueGame()
        {
            gameObject.SetActive(false); // - это удалить
            Time.timeScale = 1; // - это удалить
           // InterstitialAd.Show(OnOpenCallback, OnCloseCallback, OnErrorCallback);
           print("тут исправить");
        }

        public void OnVisibleSettingCanvas() => 
            _canvasSetting.gameObject.SetActive(true);

        private void OnErrorCallback(string obj)
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }

        private void OnCloseCallback(bool obj)
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }

        private void OnOpenCallback() => 
            throw new NotImplementedException();
    }
}