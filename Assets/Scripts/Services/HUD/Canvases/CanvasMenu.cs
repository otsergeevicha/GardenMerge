using System;
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
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        
        public void OnVisibleSettingCanvas() => 
            _canvasSetting.gameObject.SetActive(true);
    }
}