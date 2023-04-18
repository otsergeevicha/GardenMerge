using CrazyGames;
using GameAnalyticsSDK;
using Infrastructure.SaveLoadLogic;
using Services.Sound;
using UnityEngine;

namespace Services.HUD.Canvases
{
    public class CanvasProposal : MonoBehaviour
    {
        [SerializeField] private CanvasHud _canvasHud;
        [SerializeField] private SaveLoad _saveLoad;
        [SerializeField] private SoundOperator _soundOperator;
        [SerializeField] private CanvasWarning _canvasWarning;

        private const int RewardMoney = 300;

        public void OnVisible()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:Proposal:Open");

            LockGame();
        }

        public void OffVisible()
        {
            UnLockGame();
        }

        public void SeeReward()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:Proposal:VideoAd:Open");
            LockGame();
            _soundOperator.Mute();

            CrazyAds.Instance.beginAdBreakRewarded(SuccessCallback, ErrorCallback);
        }

        private void ErrorCallback()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:Proposal:VideoAd:Error");
            UnLockGame();
            _soundOperator.UnMute();
        }

        private void SuccessCallback()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:Proposal:VideoAd:Reward");
            _saveLoad.ApplyMoneyGift(RewardMoney);
            UnLockGame();
            _soundOperator.UnMute();
        }

        private void UnLockGame()
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
            _canvasHud.gameObject.SetActive(true);
        }

        private void LockGame()
        {
            _canvasWarning.gameObject.SetActive(true);
            _canvasWarning.OffCoroutine();
            _canvasWarning.gameObject.SetActive(false);
            Time.timeScale = 0;
            gameObject.SetActive(true);
            _canvasHud.gameObject.SetActive(false);
        }
    }
}