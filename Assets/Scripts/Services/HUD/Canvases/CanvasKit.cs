using UnityEngine;

namespace Services.HUD.Canvases
{
    public class CanvasKit : MonoBehaviour
    {
        public void OnVisible() =>
            gameObject.SetActive(true);

        public void OffVisible() =>
            gameObject.SetActive(false);
    }
}