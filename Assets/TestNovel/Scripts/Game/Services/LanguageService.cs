using System.Collections.Generic;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace TestNovel.Scripts.Game.Services
{
    public class LanguageService : ILanguageService
    {
        private Dictionary<string, Locale> localeNameToLocale = new();

        public LanguageService()
        {
            foreach (var locale in LocalizationSettings.AvailableLocales.Locales)
            {
                localeNameToLocale.Add(locale.LocaleName, locale);
            }
        }
        
        public void ChangeLanguage(string language)
        {
            if (localeNameToLocale.TryGetValue(language, out var locale))
            {
                LocalizationSettings.Instance.SetSelectedLocale(locale);
            }
        }
    }

    public static class Languages
    {
        public static string RUSSIAN = "Russian (ru)";
        public static string ENGLISH = "English (en)";
    }

    public enum ELanguage
    {
        Russian,
        English,
    }
}