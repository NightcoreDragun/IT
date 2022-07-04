/*
 * Palalau Alexandru
 * Display Characters available in the character selector and create the character chosen by the player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;




public class CharacterChoice : MonoBehaviour
{
    private Characters[] character;
    private int _characterIndex=0;
    public TMPro.TextMeshProUGUI Race;
    public Image characterPortrait;
    // Start is called before the first frame update
    void Start()
    {
        //get default Characters that are as Object and convert/cast them in Characters
        character = Resources.LoadAll("ScriptableObject/Characters/MainUserCharacter/OriginalsDefault", typeof(Characters)).Cast<Characters>().ToArray();
        DisplayCharacter();

    }
    void DisplayCharacter() 
    {
        Race.text = character[_characterIndex].race;
        characterPortrait.sprite = character[_characterIndex].characterPortrait;
    }
    public void NextCharacter() 
    { 
        _characterIndex++;
        if (_characterIndex>character.Length-1)
        {
            _characterIndex = 0;           
        }
        DisplayCharacter();

    }
    public void BackCharacter() 
    {
        _characterIndex--;
        if (_characterIndex<0)
        {
            _characterIndex = character.Length-1;         
        }
        DisplayCharacter();

    }

    public void CreateNewGame() 
    {
        //recupere l'ID du personnage apres la creation
       string characterID = SaveLoadCharacterSystem.SaveCharacterDataBinnaryFormat(character[_characterIndex]);
        //Position de depart du personnage
       float[] position;
       position = new float[2];
       position[0] = 4.309454f;
       position[1]= 6.120372f;
       SaveLoadGameSystem.CreateSave("StartForest", characterID, position);
    }
   

}
