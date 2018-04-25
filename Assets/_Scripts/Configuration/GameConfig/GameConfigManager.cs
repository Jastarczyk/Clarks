using Assets._Scripts.Configuration.GameConfig.Model;
using System.IO;
using UnityEngine;

namespace Assets._Scripts.Configuration.GameConfig
{
    class GameConfigManager
    {
        private static GameSettings gameSettings;

        public GameConfigManager()
        {
            string settingFileFullPath = Path.Combine(Application.streamingAssetsPath, Conf.SettingFilePath);
            gameSettings = LoadGameSettingsFile(settingFileFullPath);
        }

        //TODO should combine it with loading transalction file and replace load and save methods with generic types
        public static GameSettings GetGameSettings()
        {
            return gameSettings;
        }

        private GameSettings LoadGameSettingsFile(string path)
        {
            if (!File.Exists(path))
            {
                Debug.LogError("Can't found gameSetting file at path: " + path);
                return new GameSettings();
            }

            string loadedData = File.ReadAllText(path);
            GameSettings loadedGameSettings = JsonUtility.FromJson<GameSettings>(loadedData);

            return loadedGameSettings;
        }

        public void SaveGameSettingFile(string path)
        {
            if (!File.Exists(path))
            {
                Debug.LogError("Can't found gameSetting file at path: " + path);
                return;
            }

            var serializedData = JsonUtility.ToJson(gameSettings);
            File.WriteAllText(path, serializedData);
        }
    }
}
