using Assets._Scripts.Configuration.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets._Scripts.Configuration.GameConfig.Model
{
    [Serializable]
    public class GameSettings
    {
        public string Language;
        //sound volume as string type is much easer to deal with (but not scrict value control)
        public string SoundVolume;
        public string SkipIntro;
    }
}
