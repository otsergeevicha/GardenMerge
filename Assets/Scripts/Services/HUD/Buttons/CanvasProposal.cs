using Agava.YandexGames;
using Infrastructure.SaveLoadLogic;
using Services.HUD.Canvases;
using Services.Sound;
using UnityEngine;

namespace Services.HUD.Buttons
{
    public class CanvasProposal : MonoBehaviour
    {
        [SerializeField] private CanvasHud _canvasHud;
        [SerializeField] private SaveLoad _saveLoad;
        [SerializeField] private SoundOperator _soundOperator;
        
        private const int RewardMoney = 300;

        public void OnVisible() =>
            LockGame();

        public void OffVisible() =>
            InterstitialAd.Show(
                delegate
                {
                    LockGame();
                    _soundOperator.Mute();
                },
                delegate
                {
                    UnLockGame();
                    _soundOperator.UnMute();
                },
                delegate
                {
                    UnLockGame();
                    _soundOperator.UnMute();
                });

        public void SeeReward() =>
            VideoAd.Show(
                delegate
                {
                    LockGame();
                    _soundOperator.Mute();
                }, delegate
                {
                    _saveLoad.ApplyMoneyGift(RewardMoney);
                    UnLockGame();
                    _soundOperator.UnMute();
                },
                delegate
                {
                    UnLockGame();
                    _soundOperator.UnMute();
                },
                delegate
                {
                    UnLockGame();
                    _soundOperator.UnMute();
                });
        
        private void UnLockGame()
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
            _canvasHud.gameObject.SetActive(true);
        }

        private void LockGame()
        {
            Time.timeScale = 0;
            gameObject.SetActive(true);
            _canvasHud.gameObject.SetActive(false);
        }
    }
}