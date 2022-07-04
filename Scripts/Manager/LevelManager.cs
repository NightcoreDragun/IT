/*
 * Palalau Alexandru
 * Manage the levels.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    /// <summary>
    /// Load first level of the game
    /// </summary>
    public void NewGameMenu() => SceneManager.LoadScene("StartForest");

    /// <summary>
    /// Load the gived scene
    /// </summary>
    /// <param name="name">Scene name</param>
    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

}
