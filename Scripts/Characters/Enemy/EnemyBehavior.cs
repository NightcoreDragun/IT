/*
 * Palalau Alexandru
 * 06.05.2022
 * Allows to manage the behavior of the object. If the player enters the trigger area the object moves towards the player. If the player leaves the trigger area the object moves to the center of the starting area.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float enemyRadiusDetection=2.1f;
    private CircleCollider2D playerDetectionZone;
    private void Start()
    {
        playerDetectionZone = GetComponent<CircleCollider2D>();
        playerDetectionZone.isTrigger = true;
        playerDetectionZone.radius = enemyRadiusDetection;
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.GetComponentInParent<Animator>().SetTrigger("Run");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.GetComponentInParent<Animator>().SetTrigger("BackToStartZone");

        }
    }
}
