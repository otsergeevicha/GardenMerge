using Infrastructure.SaveLoadLogic;
using Lean.Localization;
using UnityEngine;

namespace Services.HUD.Canvases
{
    public class CanvasSetting : MonoBehaviour
    {
        [SerializeField] private CanvasHud _canvasHud;

        public void SetLanguage(string currentLanguage) => 
            LeanLocalization.SetCurrentLanguageAll(currentLanguage);

        public void OffVisible()
        {
            _canvasHud.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}