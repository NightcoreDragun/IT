/*
 * Palalau Alexandru
 * Save and load Character Data
 */
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class SaveLoadCharacterSystem : MonoBehaviour
{
    /// <summary>
    /// Serialize in binary the charaacter data
    /// </summary>
    /// <param name="character">Character that we wanna serialize</param>
    public static string SaveCharacterDataBinnaryFormat(Characters character) 
    {
        //Get actual date to use as unique ID
        string actualDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
        //Path for the save file
        const string CHARACTER_SAVE_FOLDER = "/save/characters/";
        string pathCharacterSave = Application.persistentDataPath + CHARACTER_SAVE_FOLDER;
        
        //Check if the folder doesnt exists
         if (!Directory.Exists(pathCharacterSave))
        {
            //create a new folder
            Directory.CreateDirectory(pathCharacterSave);
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(pathCharacterSave + character.name+ actualDateTime + ".dataCharacter");
        CharacterData data = new(character);
        bf.Serialize(file, data);
        file.Close();
        return character.name + actualDateTime;
    }


    /// <summary>
    /// Deserialize the character data
    /// </summary>
    /// <param name="CharacterID"></param>
    /// <returns></returns>
    public static CharacterData LoadCharacter(string CharacterID) 
    {
        //Path for the save file
        const string CHARACTER_SAVE_FOLDER = "/save/characters/";
        string pathCharacterSave = Application.persistentDataPath + CHARACTER_SAVE_FOLDER+ CharacterID+ ".dataCharacter";

        if (File.Exists(pathCharacterSave))
        {

            BinaryFormatter formatter = new();
            FileStream stream = new(pathCharacterSave, FileMode.Open);

            CharacterData data = formatter.Deserialize(stream) as CharacterData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogWarning("Save character file not found in" + pathCharacterSave);
            return null;
        }

    }
}
