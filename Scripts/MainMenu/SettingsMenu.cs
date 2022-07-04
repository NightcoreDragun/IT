/*
 * Palalau Alexandru
 * Allows to manage the game settings whit the menu
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class SettingsMenu : MonoBehaviour
{
    //Public variables/objects for the game
    Resolution[] resolutions;
    public Slider volumeSlider;
    public Toggle fullScreenToggle;
    public Sprite[] toggleState;
    public AudioMixer audioMixer;
    public TMPro.TMP_Dropdown languageChoice;
    public TMPro.TMP_Dropdown resolutionDropdown;
    private List<string> _resolutionOptions;


    //Serializeble variables for saves
    [HideInInspector]
    public float volume;
    [HideInInspector]
    public string resolution;
    [HideInInspector]
    public bool fullScreen;
    [HideInInspector]
    public int languageIndex;
    
   
    IEnumerator Start()
    {
        ResolutionList();
        yield return LanguageList();
        //FullScreenToggle();
    }



    /// <summary>
    // Show the right menu according to the current scene 
    /// </summary>
    public void BackTo() 
    {
        if (SceneManager.GetActiveScene().name!="MainMenu")
        {
            this.gameObject.transform.Find("MainMenu Canva").gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.transform.Find("Settings Menu").gameObject.SetActive(false);
            this.gameObject.transform.Find("Main Menu").gameObject.SetActive(true);


        }
    }
    public void QuitGame() 
    {
        Application.Quit();
    }

    /// <summary>
    /// Show all resolution for the client in a dropdown
    /// </summary>
    public void ResolutionList()
    {
        GetResolutions(out _resolutionOptions);
        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(_resolutionOptions);
        resolutionDropdown.RefreshShownValue();
    }




    /// <summary>
    /// Get all disponible resolutions for the client
    /// </summary>
    /// <param name="resolutionOptions"></param>
    /// <param name="currentResolutionIndex"></param>
    private void GetResolutions(out List<string> resolutionOptions)
    {
        resolutions = Screen.resolutions;
        resolutionOptions = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " : " + resolutions[i].refreshRate + "fps";
            resolutionOptions.Add(option);
        }

    }


    /// <summary>
    /// Update resolution for the client from the menu
    /// </summary>
    /// <param name="resolutionIndex">index of the chosen resolution</param>
    public void SetResolution(int resolutionIndex)
    {
        if (resolutions == null)
        {
            GetResolutions(out _resolutionOptions);
        }

        Resolution resolution = resolutions[resolutionIndex];
        this.resolution = _resolutionOptions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);


    }

    /// <summary>
    /// Update resolution from the save
    /// </summary>
    /// <param name="resolutiontData">Resolution saved</param>
    public void SetResolution(string resolutionDataSave)
    {
        int resolutionIndex = 0;
        if (resolutions == null)
        {
            GetResolutions(out _resolutionOptions);
        }

        for (int i = 0; i < _resolutionOptions.Count; i++)
        {
            if (_resolutionOptions[i] == resolutionDataSave)
            {
                resolutionIndex = i;
            }
        }
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }


    /// <summary>
    /// Default saved resolution
    /// </summary>
    public void SetResolution()
    {
        int resolutionIndex = 0;

        if (resolutions == null)
        {
            GetResolutions(out _resolutionOptions);
        }
        for (int i = 0; i < _resolutionOptions.Count; i++)
        {
            if (_resolutionOptions[i] == Screen.currentResolution.width + " x " + Screen.currentResolution.height + " : " + Screen.currentResolution.refreshRate + "fps")
            {
                resolutionIndex = i;
            }

        }
        Resolution resolution = resolutions[resolutionIndex];
        this.resolution = _resolutionOptions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }



    /// <summary>
    /// Change game volume
    /// </summary>
    /// <param name="volume">volume level</param>
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        this.volume = volume;
        volumeSlider.value = volume;


    }


    /// <summary>
    /// Change game quality (not implemented in the menu)
    /// </summary>
    /// <param name="qualityIndex">index of the quality system in unity</param>
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    /// <summary>
    /// Change the game on fullscreen or windowed
    /// </summary>
    /// <param name="isFullScreen">boolean of fullscreen</param>
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        fullScreen = isFullScreen;

    }
    /// <summary>
    /// Change sprite image and the text of the fullscreen/windowed button
    /// </summary>
    public void FullScreenToggle()
    {
        TMPro.TextMeshProUGUI fullScreenToggleText = fullScreenToggle.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        if (Screen.fullScreen == true)
        {
            fullScreenToggle.image.sprite = toggleState[0];

            fullScreenToggleText.text = LocalizationSettings.StringDatabase.GetLocalizedString("MainMenu", "Full Screen");

        }
        else
        {
            fullScreenToggle.image.sprite = toggleState[1];
            fullScreenToggleText.text = LocalizationSettings.StringDatabase.GetLocalizedString("MainMenu", "Windows Screen");
        }
    }





    /// <summary>
    /// Language list of the game
    /// </summary>
    IEnumerator LanguageList()
    {
        // Wait for the localization system to initialize
        yield return LocalizationSettings.InitializationOperation;

        // Generate list of available Locales
        var options = new List<TMPro.TMP_Dropdown.OptionData>();
        int selected = 0;
        for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; ++i)
        {
            var locale = LocalizationSettings.AvailableLocales.Locales[i];
            if (LocalizationSettings.SelectedLocale == locale)
                selected = i;
            options.Add(new TMPro.TMP_Dropdown.OptionData(locale.name));
        }
        languageChoice.options = options;
        languageChoice.value = selected;
    }

    /// <summary>
    /// Update language from the save
    /// </summary>
    /// <param name="indexLanguage">index of the language saved</param>
    public IEnumerator SetLanguage(int indexLanguage)
    {
        yield return LanguageList();
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[indexLanguage];
        languageChoice.value = indexLanguage;
        languageIndex = indexLanguage;
    }



    /// <summary>
    /// Update language from the menu
    /// </summary>
    public void SetLanguage() 
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[languageChoice.value];
        languageIndex = languageChoice.value;
    }

}
