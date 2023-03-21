using Services.HUD.Canvases;
using TMPro;
using UnityEngine;

namespace Services.HUD.Buttons
{
    public class ButtonSubscribe : MonoBehaviour
    {
        [SerializeField] private CustomTimer _customTimer;

        [SerializeField] private CanvasSubscribe _canvasSubscribe;
        [SerializeField] private TMP_Text _statusSubscribe;

        private void Update()
        {
            _statusSubscribe.text = _customTimer.TimerText.text;
        }

        public void OnVisibleCanvas()
        {
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