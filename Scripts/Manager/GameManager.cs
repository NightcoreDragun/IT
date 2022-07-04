/*
 * Palalau Alexandru
 * Manage all the data of the game, initialize all others managers
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
public class GameManager : MonoBehaviour
{
    public static GameManager gameManager = null;
    public static MenuManager menuManager = null;
    public static LevelManager levelManager = null;

    /// <summary>
    /// Initialization of the managers
    /// </summary>
    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else if (gameManager != this)
        {
            Destroy(gameObject);
        }

        if (menuManager == null)
        {
            menuManager = GetComponent<MenuManager>();
        }
        if (levelManager == null)
        {
            levelManager = GetComponent<LevelManager>();
        }


        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(gameManager);
    }
 
}
