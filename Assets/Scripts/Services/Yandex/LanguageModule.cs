using Agava.YandexGames;
using Lean.Localization;
using UnityEngine;

namespace Services.Yandex
{
    public class LanguageModule : MonoBehaviour
    {
        private const string RussianLanguage = "Russian";
        private const string TurkishLanguage = "Turkish";
        private const string EnglishLanguage = "English";
        private const string GermanLanguage = "German";

        private string _currentLanguage;

        private void Start() => 
            SetLanguage();

        private void SetLanguage()
        {
            switch (YandexGamesSdk.Environment.i18n.lang)
            {
                case "en":
                    LeanLocalization.SetCurrentLanguageAll(EnglishLanguage);
                    break;
                case "tr":
                    LeanLocalization.SetCurrentLanguageAll(TurkishLanguage);
                    break;
                case "ru":
                    LeanLocalization.SetCurrentLanguageAll(RussianLanguage);
                    break;
                case "de":
                    LeanLocalization.SetCurrentLanguageAll(GermanLanguage);
                    break;
                default:
                    LeanLocalization.SetCurrentLanguageAll(EnglishLanguage);
                    break;
            }
        }
    }
}