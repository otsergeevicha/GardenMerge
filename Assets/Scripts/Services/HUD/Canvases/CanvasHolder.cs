using Services.HUD.Canvases.Gift;
using UnityEngine;

namespace Services.HUD.Canvases
{
    public class CanvasHolder : MonoBehaviour
    {
        [SerializeField] private GameObject[] _canvasHolders;
        [SerializeField] private CanvasHud _canvasHud;
        [SerializeField] private CanvasMenu _canvasMenu;

        private void Start()
        {
            foreach (GameObject holder in _canvasHolders)
            {
                holder.SetActive(false);
            }

            Time.timeScale = 0;
            
            _canvasHud.gameObject.SetActive(true);
            _canvasMenu.gameObject.SetActive(true);
        }
    }
}