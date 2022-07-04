/*
 * Palalau Alexandru
 * Character Data Save Structure
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Characters : ScriptableObject
{
    /// <summary>
    /// Character Level
    /// </summary>
    public int lvl;
    
    /// <summary>
    /// Character HP
    /// </summary>
    public int vit;
    
    /// <summary>
    /// Character Mana
    /// </summary>
    public int inte; //INT STAT
    
    /// <summary>
    /// Character Strenght
    /// </summary>
    public int str;
    
    /// <summary>
    /// Character Defence
    /// </summary>
    public int dex;
    
    /// <summary>
    /// Character mouvement speed
    /// </summary>
    public int mouvementSpeed;
    
    /// <summary>
    /// Sprint speed
    /// </summary>
    public int sprintSpeed;
    
    /// <summary>
    /// Character attack speed
    /// </summary>
    public int attaqueSpeed;
    
    /// <summary>
    /// Character Race 
    /// </summary>
    public string race;
    
    /// <summary>
    /// Character portrait 
    /// </summary>
    public Sprite characterPortrait;

    /// <summary>
    /// Character body
    /// </summary>
    public RuntimeAnimatorController characterAnimator;
}
