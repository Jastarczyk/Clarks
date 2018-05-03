using Assets._Scripts.Configuration.GameConfig.Model;
using Assets._Scripts.Configuration.Localization;
using System;
using System.IO;
using UnityEngine;

namespace Assets._Scripts.Configuration.GameConfig
{
    static class GameConfigManager
    {
        private static GameSettings gameSettings;
        private static string settingFileFullPath;

        public static GameSettings GetGameSettings()
        {
            if (gameSettings == null)
            {
                settingFileFullPath = Path.Combine(Application.streamingAssetsPath, Conf.SettingFilePath);
                gameSettings = LoadGameSettingsFile(settingFileFullPath);
            }

            return gameSettings;
        }

        private static GameSettings LoadGameSettingsFile(string path)
        {
            if (!File.Exists(path))
            {
                Debug.LogError("Can't found gameSetting file at path: " + path);
            }

            string loadedData = File.ReadAllText(path);
            GameSettings loadedGameSettings = JsonUtility.FromJson<GameSettings>(loadedData);

            loadedGameSettings = ValidateLoadedSettings(loadedGameSettings);
            LoadPlayerPrefsBasingOnJson(loadedGameSettings);

            return loadedGameSettings;
        }

        public static void SaveGameSetting(GameSettings newSettings)
        {
            newSettings = NewSettingOverrideProtector(newSettings);

            if (!File.Exists(settingFileFullPath))
            {
                Debug.LogError("Can't found gameSetting file at path: " + settingFileFullPath);
                return;
            }

            var serializedData = JsonUtility.ToJson(newSettings);
            File.WriteAllText(settingFileFullPath, serializedData);
        }

        private static GameSettings ValidateLoadedSettings(GameSettings gameSettings)
        {
            gameSettings.Language = String.IsNullOrEmpty(gameSettings.Language) ? Languages.English.ToString(): gameSettings.Language;
            gameSettings.SkipIntro = String.IsNullOrEmpty(gameSettings.SkipIntro) ? default(int).ToString() : gameSettings.SkipIntro;
            gameSettings.SoundVolume = String.IsNullOrEmpty(gameSettings.SoundVolume) ? "100" : gameSettings.SoundVolume;

            return gameSettings;
        }

        private static GameSettings NewSettingOverrideProtector(GameSettings newSettings)
        {
            newSettings.Language = String.IsNullOrEmpty(newSettings.Language) ? gameSettings.Language : newSettings.Language;
            newSettings.SoundVolume = String.IsNullOrEmpty(newSettings.SoundVolume) ? gameSettings.SoundVolume : newSettings.SoundVolume;
            newSettings.SkipIntro = String.IsNullOrEmpty(newSettings.SkipIntro) ? gameSettings.SkipIntro : newSettings.SkipIntro;

            return newSettings;
        }

        private static void LoadPlayerPrefsBasingOnJson(GameSettings settings)
        {
            if (settings != null)
            {
                PlayerPrefs.SetString(Conf.PlayerPrefSoundVolumeName, settings.SoundVolume);

                PlayerPrefs.SetString(Conf.PlayerPrefIntroSkipName, settings.SkipIntro);

                PlayerPrefs.SetString(Conf.PlayerPrefLanguageName, settings.Language);
            }
            else Debug.LogError("Trying to set player prefs with empty settings!");
        }
    }
}
