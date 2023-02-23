using Services.HUD.Buttons;
using UnityEngine;

namespace Services.HUD.Canvases
{
    public class CanvasMenu : MonoBehaviour
    {
        [SerializeField] private CanvasSetting _canvasSetting;
        [SerializeField] private CanvasLeaderBoard _canvasLeaderBoard;

        [SerializeField] private ButtonHolderMenu _buttonHolderMenu;

        private void Start() => 
            Time.timeScale = 0;

        public void ContinueGame()
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        
        public void OnVisibleSettingCanvas() => 
            _canvasSetting.gameObject.SetActive(true);
        
        public void OnVisibleLeaderBoard()
        {
            _buttonHolderMenu.gameObject.SetActive(false);
            _canvasLeaderBoard.gameObject.SetActive(true);
        }
    }
}