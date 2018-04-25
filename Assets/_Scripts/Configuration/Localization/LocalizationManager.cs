using Assets._Scripts.Configuration;
using Assets._Scripts.Configuration.GameConfig;
using Assets._Scripts.Configuration.Localization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Scripts.Global
{
    public class LocalizationManager
    {
        private Languages currentGameLanguage;
        private static Dictionary<string, string> localizationDictionary;

        public LocalizationManager()
        {
            LoadGameLanguage();
            string translationFileFullPath = Path.Combine(Application.streamingAssetsPath, Conf.TranslationFilePaths[currentGameLanguage]);
            var loadedLocalizationCollection = LoadLocalizationFile(translationFileFullPath);
            FillLocalizationDictionary(loadedLocalizationCollection);
        }

        public Dictionary<string, string> GetLocalizationDictionary()
        {
            return localizationDictionary;
        }

        private LocalizationItemsCollection LoadLocalizationFile(string path)
        {
            if (!File.Exists(path))
            {
                Debug.LogError("Can't found localization file at path: " + path);
                return new LocalizationItemsCollection();
            }

            string loadedData = File.ReadAllText(path);
            return JsonUtility.FromJson<LocalizationItemsCollection>(loadedData);
        }

        private void FillLocalizationDictionary(LocalizationItemsCollection collection)
        {
            localizationDictionary = new Dictionary<string, string>();

            if (collection.ItemsCollection == null)
            {
                Debug.Log("Loaded Collection is empty");
                return;
            }

            foreach (LocalizationItem item in collection.ItemsCollection)
            {
                localizationDictionary.Add(item.ItemName, item.Text);
            }
        }

        private void LoadGameLanguage()
        {
            switch (GameConfigManager.GetGameSettings().Language)
            {
                case "English":
                    currentGameLanguage = Languages.English;
                    break;

                case "Polish":
                    currentGameLanguage = Languages.Polish;
                    break;

                default:
                    currentGameLanguage = Languages.English;
                    break;
            }
        }
    }
}

