using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets._Scripts.Global;
using System.Linq;

public class IntroLanguageManager : MonoBehaviour
{
    private Text[] GUITextComponents;

    void Awake()
	{
        GUITextComponents = GameObject.FindGameObjectWithTag("ActiveGUI").GetComponentsInChildren<Text>();
	}

    private void Start()
    {
        IntroGUIManagment.OnContinueButtonClick += IntroGUIManagment_OnContinueButtonClick;
        SetSceneTranslation();
    }

    private void IntroGUIManagment_OnContinueButtonClick(string itemName)
    {
        if (TranslationManager.GetLocalizationDictionary().ContainsKey(itemName))
        {
            GUITextComponents.Where(x => x.transform.name.Equals("IntroPage1Label")).FirstOrDefault().text = TranslationManager
                                                                                                    .GetLocalizationDictionary()[itemName];
        }
    }

    private void SetSceneTranslation()
    {
        foreach (Text textLabel in GUITextComponents)
        {
            if (TranslationManager.GetLocalizationDictionary().ContainsKey(textLabel.name))
            {
                textLabel.text = TranslationManager.GetLocalizationDictionary()[textLabel.name];
            }
        }
    }
}
