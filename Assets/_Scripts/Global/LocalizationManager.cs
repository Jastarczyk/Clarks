using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Scripts.Global
{
    public class LocalizationManager : MonoBehaviour
    {
        private Dictionary<string, string> localizationDictionary;

        private void Awake()
        {
           // LoadLocalizationFile();
        }

        private void LoadLocalizationFile(string path)
        {
            var test = Application.streamingAssetsPath;

            throw new NotImplementedException();
        }

    }
}

