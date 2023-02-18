using Services.HUD.Buttons;
using UnityEngine;

namespace Services.HUD.Canvases
{
    public class CanvasGift : MonoBehaviour
    {
        [SerializeField] private ButtonDailySpin _dailySpin;

        public void Spin()
        {
            if (_dailySpin.CanSpin())
            {
                Twist();
            }
        }

        private void Twist()
        {
            throw new System.NotImplementedException();
        }

        public void Close() =>
            gameObject.SetActive(false);
    }
}