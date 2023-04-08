using System.Collections.Generic;
using Services.HUD.Buttons;
using UnityEngine;

namespace Services.HUD.Canvases.Training
{
    public class CanvasTraining : MonoBehaviour
    {
        [SerializeField] private CanvasMenu _canvasMenu;
        [SerializeField] private CanvasHud _canvasHud;
        
        [SerializeField] private ButtonPrev _buttonPrev;
        [SerializeField] private List<TrainingPanel> _panels = new ();
        
        private int _indexPage;

        public void OnCanvasTraining(bool status)
        {
            _canvasMenu.gameObject.SetActive(!status);
            _canvasHud.gameObject.SetActive(false);
            gameObject.SetActive(status);
            SetArrowActive();
        }
        
        public void ClickPrev()
        {
            if (_indexPage <= 0) 
                return;

            _panels[_indexPage].gameObject.SetActive(false);
            _panels[_indexPage -= 1].gameObject.SetActive(true);
            
            SetArrowActive();
        }
        
        public void ClickNext()
        {
            if (_indexPage == 3)
            {
                RestartPanels();
                OnCanvasTraining(false);
                return;
            }

            if (_indexPage >= _panels.Count - 1)
                return;

            _panels[_indexPage].gameObject.SetActive(false);
            _panels[_indexPage += 1].gameObject.SetActive(true);
            
            SetArrowActive();
        }

        private void RestartPanels()
        {
            foreach (TrainingPanel panel in _panels)
                panel.gameObject.SetActive(false);

            _indexPage = 0;
            _panels[_indexPage].gameObject.SetActive(true);
        }
        
        private void SetArrowActive()
        {
            _buttonPrev.gameObject.SetActive(_indexPage > 0);
        }
    }
}