using Assets._Scripts.Configuration.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets._Scripts.Configuration
{
    public class Conf
    {
        public const string SettingFilePath = "GameSettings.json";

        public static readonly Dictionary<Languages, string> TranslationFilePaths = new Dictionary<Languages, string>()
        {
            { Languages.English, "Translation/Default.json" },
            { Languages.Polish, "Translation/Polish.json" },
        };

        public const string PlayerPrefSoundVolumeName = "SoundVolume";
        public const string PlayerPrefLanguageName = "Language";
        public const string PlayerPrefIntroSkipName = "SkipIntro";
    }
}
