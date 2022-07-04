/*
 * Palalau Alexandru
 * Manage the menu settings, and save them if needed
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject eventSystem;
    public SettingsMenu settingsMenu;


    private void Start()
    {
        LoadSettingMenu();
    }
    public void Awake()
    {
        DontDestroyOnLoad(menu);
        DontDestroyOnLoad(eventSystem);
        if (settingsMenu == null)
        {
            settingsMenu = GetComponent<SettingsMenu>();
        }
    }

    
    /// <summary>
    /// Show/hide menu if we press Escape and if we are not in MainMenu scene
    /// </summary>
    public void Update()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menu.SetActive(!menu.activeSelf);
               //il faut encore activer le settings menu
            }
        }
    }

    //Once the scene changed we check if the main camera still exists
    public void OnLevelWasLoaded(int level)
    {
        if (menu.GetComponent<Canvas>().worldCamera==null)
        {
            menu.GetComponent<Canvas>().worldCamera = Camera.main;
        }
    }

    /// <summary>
    /// Save the settings of the menu
    /// </summary>
    public void SaveSettingMenu()
    {
        SaveLoadSettingsMenuSystem.SaveSettingsMenuBinnaryFormat(settingsMenu);
    }

    /// <summary>
    /// Load game preference settings if exist else set default settings
    /// </summary>
    public void LoadSettingMenu()
    {
        SettingsMenuData data = SaveLoadSettingsMenuSystem.LoadSettingsMenu();

        if (data != null)
        {
            settingsMenu.SetResolution(data.resolution);
            settingsMenu.SetFullScreen(data.fullScreen);
            settingsMenu.SetVolume(data.volume);
            StartCoroutine(settingsMenu.SetLanguage(data.languageIndex));
        }
        else
        {
            settingsMenu.SetResolution();
            SaveSettingMenu();
        }
    }

}
