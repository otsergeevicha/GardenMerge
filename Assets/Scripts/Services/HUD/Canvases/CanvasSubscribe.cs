using System;
using Agava.YandexGames;
using Infrastructure.SaveLoadLogic;
using Services.Sound;
using UnityEngine;

namespace Services.HUD.Canvases
{
    public class CanvasSubscribe : MonoBehaviour
    {
        [SerializeField] private SaveLoad _saveLoad;
        
        [SerializeField] private SoundOperator _soundOperator;

        public void See() => 
            VideoAd.Show(OnOpenCallback, OnRewardedCallback, OnCloseCallback, OnErrorCallback);

        private void OnOpenCallback()
        {
            Time.timeScale = 0;
            _soundOperator.Mute();
        }

        private void OnRewardedCallback()
        {
            if (_saveLoad.ReadStatusSubscribe() == false)
            {
                _saveLoad.ChangeStatusSubscribe(true);
                _saveLoad.ChangeStatusTempSubscribe(true);
            }
            
            UnLockGame();
        }

        private void OnCloseCallback() => 
            UnLockGame();

        private void OnErrorCallback(string obj)
        {
            Debug.Log(obj);
            UnLockGame();
        }

        private void UnLockGame()
        {
            Time.timeScale = 1;
            _soundOperator.UnMute();
        }
    }
}