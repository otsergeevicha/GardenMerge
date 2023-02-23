using Services.HUD.Buttons;
using UnityEngine;

namespace Services.HUD.Canvases
{
    public class CanvasLeaderBoard : MonoBehaviour
    {
        [SerializeField] private ButtonHolderMenu _buttonHolderMenu;

        public void OffVisible()
        {
            _buttonHolderMenu.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}