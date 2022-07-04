/*
 * Palalau Alexandru
 * 05.05.2022
 * Allows to manage the interaction of the layers between the player and the different objects of the map. If it is the player who is displayed on top of the object X or the opposite.
 * It is also possible to change scene by contacting a gameObject which has a trigger collider with the name of the scene to change.
 * The game object must be the child of a parent called "SceneTriggers".
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LevelManager))]
public class PlayerInteraction : MonoBehaviour
{
    private LevelManager levelManager;


    private void Start()
    {  
        this.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "PlayerFront";
        levelManager = GetComponent<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Find the scene that matches the child's name
        if (collision.gameObject.transform.parent.gameObject.name== "SceneTriggers")
        {
            levelManager.LoadLevel(collision.gameObject.name);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Put the player behind the object and make him transparent
        if (collision.gameObject.transform.parent.gameObject.name == "TransparentObjects")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
            this.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "PlayerBack";
        }

        ////Regarde ou se trouve le joueur par apport a l'enemy et le met devant ou derriere en function de la position du joueur
        //if (collision.gameObject.transform.parent.gameObject.name == "Enemy" && collision.transform.position.y < this.gameObject.transform.position.y)
        //{
        //    this.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "PlayerBackEnemy";
        //}
        //else if (collision.gameObject.transform.parent.gameObject.name == "Enemy" && collision.transform.position.y >= this.gameObject.transform.position.y)
        //{
        //    this.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "PlayerFrontEnemy";
        //}

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Puts the player in front of the object and makes the object opaque
        if (collision.gameObject.transform.parent.gameObject.name == "TransparentObjects")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            this.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "PlayerFront";
        }
    }
}
