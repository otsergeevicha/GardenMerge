using System;
using UnityEngine;

namespace Services.HUD.Canvases
{
    public class CanvasPause : MonoBehaviour
    {
        [SerializeField] private CanvasSetting _canvasSetting;
        [SerializeField] private CanvasHud _canvasHud;
        [SerializeField] private CanvasMenu _canvasMenu;

        public void OnVisibleCanvasSetting()
        {
            _canvasHud.gameObject.SetActive(false);
            _canvasSetting.gameObject.SetActive(true);
        }
        
        public void Visible(bool status)
        {
            _canvasHud.gameObject.SetActive(true);
            gameObject.SetActive(status);
        }

        public void OnMenu()
        {
            _canvasMenu.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}