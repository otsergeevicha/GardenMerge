using Agava.YandexGames;
using UnityEngine;

namespace Services.HUD.Canvases
{
    public class CanvasAuthorization : MonoBehaviour
    {
        public void OnVisible() => 
            gameObject.SetActive(true);

        public void LogIn()
        {
            OffVisible();
            PlayerAccount.Authorize();
        }

        private void OffVisible() => 
            gameObject.SetActive(false);
    }
}