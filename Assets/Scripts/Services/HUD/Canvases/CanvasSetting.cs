using Lean.Localization;
using UnityEngine;

namespace Services.HUD.Canvases
{
    public class CanvasSetting : MonoBehaviour
    {
        public void SetLanguage(string currentLanguage) => 
            LeanLocalization.SetCurrentLanguageAll(currentLanguage);

        public void OffVisible() => 
            gameObject.SetActive(false);
    }
}