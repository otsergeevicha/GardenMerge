using UnityEngine;

namespace Services.HUD.Canvases.AlmanacLogic
{
    public class CanvasAlmanac : MonoBehaviour
    {
        [SerializeField] private CanvasHud _canvasHud;
        [SerializeField] private ViewAlmanac _viewAlmanac;

        public void OnVisible(int levelVegetation, int countMerge, int totalCountMoney)
        {
            LockGame();
            
            _viewAlmanac.Show(levelVegetation, countMerge, totalCountMoney);
            Time.timeScale = 0;
            gameObject.SetActive(true);
        }

        public void OffVisible() => 
            UnLockGame();

        private void LockGame() => 
            _canvasHud.gameObject.SetActive(false);

        private void UnLockGame()
        {
            _canvasHud.gameObject.SetActive(true);
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
    }
}