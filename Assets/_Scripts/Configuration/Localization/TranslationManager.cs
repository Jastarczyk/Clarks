using Assets._Scripts.Configuration;
using Assets._Scripts.Configuration.GameConfig;
using Assets._Scripts.Configuration.Localization;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using UnityEngine;

namespace Assets._Scripts.Global
{
    public class TranslationManager : MonoBehaviour
    {
        private static Dictionary<string, string> localizationDictionary;
        public static Languages CurrentGameLanguage { get; private set; }

        public static void SetCurrentGameLanguage(string language)
        {
            CurrentGameLanguage = ConcludeGameLanguage(language);
        }

        public static void SetCurrentGameLanguage(Languages language)
        {
            CurrentGameLanguage = ConcludeGameLanguage(language.ToString());
        }

        public static Dictionary<string, string> GetLocalizationDictionary()
        {
            if (localizationDictionary == null)
            {
                localizationDictionary = FillLocalizationDictionary(CurrentGameLanguage);
            }

            return localizationDictionary;
        }

        private void Awake()
        {
            //set default game language basing on game settings
            SetCurrentGameLanguage(GameConfigManager.GetGameSettings().Language);
        }

        private void Start()
        {
            MainMenuGUIManager.OnLanguageSliderValueChanged += MainMenuManager_OnLanguageSliderValueChanged;
        }

        private void MainMenuManager_OnLanguageSliderValueChanged(Languages language)
        {
            SetCurrentGameLanguage(language);
            localizationDictionary = FillLocalizationDictionary(CurrentGameLanguage);
        }


        private static Dictionary<string, string> FillLocalizationDictionary(Languages language)
        {
            string translationFileFullPath = GetTranslationFilePath(language);
            var loadedLocalizationCollection = LoadLocalizationJsonFile(translationFileFullPath);
            return InitLocalizationDictionary(loadedLocalizationCollection);
        }

        private static string GetTranslationFilePath(Languages language)
        {
            return Path.Combine(Application.streamingAssetsPath, Conf.TranslationFilePaths[language]);
        }

        private static LocalizationItemsCollection LoadLocalizationJsonFile(string path)
        {
            if (!File.Exists(path))
            {
                Debug.LogError("Can't found localization file at path: " + path);
                return new LocalizationItemsCollection();
            }

            string loadedData = File.ReadAllText(path);
            return JsonUtility.FromJson<LocalizationItemsCollection>(loadedData);
        }

        private static Dictionary<string, string> InitLocalizationDictionary(LocalizationItemsCollection collection)
        {
            localizationDictionary = new Dictionary<string, string>();

            if (collection.ItemsCollection == null)
            {
                Debug.LogError("Loaded Collection is empty");
                return new Dictionary<string, string>();
            }

            foreach (LocalizationItem item in collection.ItemsCollection)
            {
                localizationDictionary.Add(item.ItemName, item.Text);
            }

            return localizationDictionary;
        }

        private static Languages ConcludeGameLanguage(string languageString)
        {
            switch (languageString)
            {
                case "English":
                    return Languages.English;

                case "Polish":
                    return Languages.Polish;

                default:
                    return Languages.English;
            }
        }
    }
}

