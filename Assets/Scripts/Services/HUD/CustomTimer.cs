using Infrastructure.SaveLoadLogic;
using Services.HUD.Canvases;
using TMPro;
using UnityEngine;

namespace Services.HUD
{
    public class CustomTimer : MonoBehaviour
    {
        [SerializeField] private CanvasSubscribe _canvasSubscribe;
        [SerializeField] private SaveLoad _saveLoad;
        
        [SerializeField] private bool _countDown = true;

        //[SerializeField] private TextMeshProUGUI _firstMinute;
        //[SerializeField] private TextMeshProUGUI _secondMinute;
        //[SerializeField] private TextMeshProUGUI _separator;
        //[SerializeField] private TextMeshProUGUI _firstSecond;
        //[SerializeField] private TextMeshProUGUI _secondSecond;

        [SerializeField] private float _flashDuration = 1f;

        private readonly float _timerDuration = 90f * 60f;
        
        public TextMeshProUGUI TimerText;

        private float _flashTimer;
        private float _timer;

        private void Start() =>
            ResetTimer();

        private void Update()
        {
            if (_canvasSubscribe.TemporarySubscription == false)
                return;

            if (_countDown && _timer > 0)
            {
                _timer -= Time.deltaTime;
                UpdateTimerDisplay(_timer);
            }
            else if (_countDown == false && _timer < _timerDuration)
            {
                _timer += Time.deltaTime;
                UpdateTimerDisplay(_timer);
            }
            else
                FlashTimer();
        }

        private void ResetTimer()
        {
            if (_countDown)
                _timer = _timerDuration;
            else
                _timer = 0;

            SetTextDisplay(true);
        }

        private void UpdateTimerDisplay(float time)
        {
            if (time < 0)
            {
                time = 0;
                _canvasSubscribe.TemporarySubscription = false;
                _saveLoad.ChangeStatusSubscribe(false);
            }

            if (time > 3660)
            {
                Debug.LogError("Timer cannot display values above 3660 seconds");
                ErrorDisplay();
                return;
            }

            float minutes = Mathf.FloorToInt(time / 60);
            float seconds = Mathf.FloorToInt(time % 60);

            string currentTime = string.Format("{00:00}:{1:00}", minutes, seconds);
            
            //string currentTime = $"{minutes:00}{seconds:00}";

            // _firstMinute.text = currentTime[0].ToString();
            // _secondMinute.text = currentTime[1].ToString();
            // _firstSecond.text = currentTime[2].ToString();
            // _secondSecond.text = currentTime[3].ToString();

            TimerText.text = currentTime;
        }

        private void ErrorDisplay()
        {
            // _firstMinute.text = "8";
            // _secondMinute.text = "8";
            // _firstSecond.text = "8";
            // _secondSecond.text = "8";

            TimerText.text = "ERROR";
        }

        private void FlashTimer()
        {
            if (_countDown && _timer != 0)
            {
                _timer = 0;
                UpdateTimerDisplay(_timer);
            }

            if (_countDown == false && _timer != _timerDuration)
            {
                _timer = _timerDuration;
                UpdateTimerDisplay(_timer);
            }

            if (_flashTimer <= 0)
            {
                _flashTimer = _flashDuration;
            }
            else if (_flashTimer <= _flashDuration / 2)
            {
                _flashTimer -= Time.deltaTime;
                SetTextDisplay(true);
            }
            else
            {
                _flashTimer -= Time.deltaTime;
                SetTextDisplay(false);
            }
        }

        private void SetTextDisplay(bool status)
        {
            // _firstMinute.enabled = enabled;
            // _secondMinute.enabled = enabled;
            // _separator.enabled = enabled;
            // _firstSecond.enabled = enabled;
            // _secondSecond.enabled = enabled;

            TimerText.enabled = status;
        }
    }
}