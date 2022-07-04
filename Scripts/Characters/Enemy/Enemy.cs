/*
 * Palalau Alexandru
 * Create all neded component to make the skeleton of the enemy and contain the basic functions of the gameplay
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LookAtPlayer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    private Rigidbody2D enemyRigidbody;
    private GameObject detectionPlayer;
    public int maxHealth = 100;
    int currentHealth;


    private void Start()
    {
        //Initialisation of rigidBody2D
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyRigidbody.freezeRotation = true;
        enemyRigidbody.mass = 0;
        enemyRigidbody.gravityScale = 0;
        enemyRigidbody.simulated = true;



        //Creation of detection area
        detectionPlayer = new GameObject("DetectionPlayer", typeof(EnemyBehavior), typeof(CircleCollider2D));
        //Set parents of the area gameObject
        detectionPlayer.transform.SetParent(transform);
        //ResetPossition
        detectionPlayer.transform.localPosition = Vector3.zero;



        //Initialization of HP
        currentHealth = maxHealth;

    }

    /// <summary>
    /// Function to take damage from the player and launch the animation.
    /// </summary>
    /// <param name="damage">The damage value that the object will take</param>
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }


    /// <summary>
    /// Launch animation die and destroy the object
    /// </summary>
    public void Die()
    {
        Destroy(gameObject);
    }
}
