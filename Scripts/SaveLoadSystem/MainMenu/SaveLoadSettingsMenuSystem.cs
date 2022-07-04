/*
 * Palalau Alexandru
 * menu settings saves system
 */
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class SaveLoadSettingsMenuSystem 
{
   


    /// <summary>
    /// Serialize in binary the settings of the menu
    /// </summary>
    /// <param name="settingsMenu">Script of the menu</param>
    public static void SaveSettingsMenuBinnaryFormat(SettingsMenu settingsMenu) 
    {
        //Path for the save file
        const string SETTINGS_SAVE_FOLDER = "/settings/";
        string pathSettingsSave = Application.persistentDataPath + SETTINGS_SAVE_FOLDER;

        //Check if the folder doesnt exists
        if (!Directory.Exists(pathSettingsSave))
        {
            //create a new folder
            Directory.CreateDirectory(pathSettingsSave);
        }

        BinaryFormatter bf = new();
        FileStream file = File.Create(pathSettingsSave + "settingsMenu.settingsMenu");
        SettingsMenuData data = new(settingsMenu);
        bf.Serialize(file, data);
        file.Close();
    }
    /// <summary>
    /// Deserialize menu data
    /// </summary>
    /// <returns>return data from the save, if no data found return null</returns>
    public static SettingsMenuData LoadSettingsMenu() 
    {
        //Path for the save file
        const string SETTINGS_SAVE_FOLDER = "/settings/settingsMenu.settingsMenu";
        string pathSettingsSave = Application.persistentDataPath + SETTINGS_SAVE_FOLDER;
        
        if (File.Exists(pathSettingsSave))
        {
            BinaryFormatter formatter = new();
            FileStream stream = new(pathSettingsSave, FileMode.Open);

            SettingsMenuData data= formatter.Deserialize(stream) as SettingsMenuData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogWarning("Save settings menu file not found in" + pathSettingsSave);
            return null;
        }
    }
  
    
}
