using GameAnalyticsSDK;
using Services.HUD.Canvases;
using UnityEngine;

namespace Services.HUD.Buttons
{
    public class ButtonGift : MonoBehaviour
    {
        [SerializeField] private CanvasGift _canvasGift;
        [SerializeField] private CanvasHud _canvasHud;

        private void Start() => 
            _canvasGift.gameObject.SetActive(false);

        public void Press()
        {
            GameAnalytics.NewDesignEvent($"ButtonClick:Roulette:Open");
            Time.timeScale = 0;
            _canvasHud.gameObject.SetActive(false);
            _canvasGift.gameObject.SetActive(true);
        }
    }
}