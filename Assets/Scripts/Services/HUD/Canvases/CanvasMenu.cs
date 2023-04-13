using System;
using Agava.YandexGames;
using UnityEngine;

namespace Services.HUD.Canvases
{
    public class CanvasMenu : MonoBehaviour
    {
        [SerializeField] private CanvasSetting _canvasSetting;
        [SerializeField] private CanvasHud _canvasHud;

        private void FixedUpdate()
        {
            if (isActiveAndEnabled == false)
                return;
            
            Time.timeScale = 0;
        }

        public void ContinueGame()
        {
            //InterstitialAd.Show(OnOpenCallback, OnCloseCallback, OnErrorCallback);
            print("и здесь тоже, удали что ниже");
            gameObject.SetActive(false);
            _canvasHud.gameObject.SetActive(true);
            Time.timeScale = 1;
        }

        public void OnVisibleSettingCanvas() => 
            _canvasSetting.gameObject.SetActive(true);

        private void OnErrorCallback(string obj)
        {
            gameObject.SetActive(false);
            _canvasHud.gameObject.SetActive(true);
            Time.timeScale = 1;
        }

        private void OnCloseCallback(bool obj)
        {
            gameObject.SetActive(false);
            _canvasHud.gameObject.SetActive(true);
            Time.timeScale = 1;
        }

        private void OnOpenCallback() => 
            throw new NotImplementedException();
    }
}