using GameAnalyticsSDK;
using Infrastructure.SaveLoadLogic;
using Services.HUD.Canvases;
using TMPro;
using UnityEngine;

namespace Services.HUD.Buttons
{
    public class ButtonSubscribe : MonoBehaviour
    {
        [SerializeField] private CanvasSubscribe _canvasSubscribe;
        
        [SerializeField] private TMP_Text _statusTempSubscribe;
        [SerializeField] private TMP_Text _statusActiveSubscribe;
        [SerializeField] private TMP_Text _statusNoActiveSubscribe;

        [SerializeField] private CustomTimer _customTimer;
        
        [SerializeField] private SaveLoad _saveLoad;

        private void Update()
        {
            if (isActiveAndEnabled == false)
                return;

            switch (_customTimer.Status)
            {
                case true:
                    _statusTempSubscribe.enabled = true;
                    _statusActiveSubscribe.enabled = false;
                    _statusNoActiveSubscribe.enabled = false;
                
                    _statusTempSubscribe.text = _customTimer.TimerText.text;
                    break;
                case false when _saveLoad.ReadStatusSubscribe():
                    _statusTempSubscribe.enabled = false;
                    _statusActiveSubscribe.enabled = true;
                    _statusNoActiveSubscribe.enabled = false;
                    break;
                case false when _saveLoad.ReadStatusSubscribe() == false:
                    _statusTempSubscribe.enabled = false;
                    _statusActiveSubscribe.enabled = false;
                    _statusNoActiveSubscribe.enabled = true;
                    break;
            }
        }

        public void SetText(string text) => 
            _statusTempSubscribe.text = text;

        public void OnVisibleCanvas()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:ButtonSubscribe");
            Time.timeScale = 0;
            _canvasSubscribe.gameObject.SetActive(true);
        }

        public void OffVisibleCanvas()
        {
            Time.timeScale = 1;
            _canvasSubscribe.gameObject.SetActive(false);
        }
    }
}