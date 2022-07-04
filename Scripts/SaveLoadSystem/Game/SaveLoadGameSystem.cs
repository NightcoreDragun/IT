/*
 * Palalau Alexandru
 * Data serialization and deserialization system for saves
 */
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;


public class SaveLoadGameSystem : MonoBehaviour
{
    private const string GAME_SAVE_FOLDER = "/save/game/";


    /// <summary>
    /// Create unique save
    /// </summary>
    /// <param name="sceneName">Name of the scene to save</param>
    /// <param name="characterID">Character ID save</param>
    /// <param name="position">Player Position</param>
    public static void CreateSave(String sceneName, String characterID, float[] position)
    {
        try
        {
            //Clear special character from the actual date
            string actualDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");

            //Path for the save file
            string pathGameSave = Application.persistentDataPath + GAME_SAVE_FOLDER;
            //Check if the folder exists
            if (!Directory.Exists(pathGameSave))
            {
                //create a new folder
                Directory.CreateDirectory(pathGameSave);
            }
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(pathGameSave + actualDateTime + ".gameData");
            GameData data = new(sceneName, characterID, position);
            bf.Serialize(file, data);
            file.Close();

            Debug.Log("Save Created");
        }
        catch (System.Exception)
        {
            Debug.LogError("Save Failed");
            throw;
        }
    }
    public static void SaveGame()
    {

    }

    /// <summary>
    /// Deserialization of the save file
    /// </summary>
    /// <param name="gameID">The name of the save file</param>
    /// <returns></returns>
    public static GameData LoadGame(string gameID)
    {
        //Path for the save file
        string pathCharacterSave = Application.persistentDataPath + GAME_SAVE_FOLDER + gameID;

        if (File.Exists(pathCharacterSave))
        {

            BinaryFormatter formatter = new();
            FileStream stream = new(pathCharacterSave, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogWarning("Save game file not found in" + pathCharacterSave);
            return null;
        }
    }
/// <summary>
/// Get alll saves files and return it
/// </summary>
/// <returns>@Array saves files </returns>
    public static List<string> GetSavesFiles()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(Application.persistentDataPath + GAME_SAVE_FOLDER);
        List<string> filesID = new();

        // Add file sizes.
        FileInfo[] fileInfo = directoryInfo.GetFiles();
        foreach (FileInfo file in fileInfo)
        {
            if (file.Extension.Equals(".gameData"))  
            {
                filesID.Add(file.Name);
            }
        }
        return filesID;
    }

    /// <summary>
    /// Create UI where the saves will be showed
    /// </summary>
    public void ShowSaves()
    {
        GameObject templateUI = Resources.Load<GameObject>("Prefab/MainMenu/SavesPanel");
        List<string> filesID = GetSavesFiles();
        foreach (string file in filesID)
        {
            GameData gameData = LoadGame(file);
            CharacterData character = SaveLoadCharacterSystem.LoadCharacter(gameData.characterID);
            templateUI = Instantiate(templateUI);
            templateUI.transform.SetParent(GameObject.Find("ContainerData").transform);
            templateUI.transform.localScale = new Vector2(200,200);
            templateUI.transform.localPosition = new Vector2(30,30);
            templateUI.transform.GetChild(1).GetComponent<TMPro.TMP_Text>().text = gameData.sceneName.ToString();
            templateUI.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text = character.race;
        }
    }

}
