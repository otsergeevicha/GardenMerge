using Services.HUD.Canvases;
using UnityEngine;

namespace Services.HUD.Buttons
{
    public class ButtonGift : MonoBehaviour
    {
        [SerializeField] private CanvasGift _canvasGift;

        private void Start() => 
            _canvasGift.gameObject.SetActive(false);

        public void Press() => 
            _canvasGift.gameObject.SetActive(true);
    }
}