/*
 * Palalau Alexandru
 * Create all component to make the skeleton of the player and contain the basic functions of the gameplay
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Light2D))]
[RequireComponent(typeof(PlayerInteraction))]
[RequireComponent(typeof(PlayerMouvement))]

public class Player : MonoBehaviour
{
    private Rigidbody2D _playerRigidbody;
    private GameObject _lightAreaPlayer;
    private GameObject _attackAreaPlayer;
    private PlayerMouvement _playerMouvement;
    // Start is called before the first frame update
    void Start()
    {
        //Initialisation of rigidBody2D
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _playerRigidbody.freezeRotation = true;
        _playerRigidbody.mass = 0;
        _playerRigidbody.gravityScale = 0;
        _playerRigidbody.simulated = true;

        //Creation light area of the player
        _lightAreaPlayer = new GameObject("AreaLightPlayer", typeof(Light2D));
        _lightAreaPlayer.transform.SetParent(transform);
        _lightAreaPlayer.transform.localPosition = Vector3.zero;

        //Creation area attack of the player
        _attackAreaPlayer = new GameObject("AttackAreaPlayer", typeof(PlayerAttack));
        _attackAreaPlayer.transform.SetParent(transform);
        _attackAreaPlayer.transform.localPosition = Vector3.zero;

        //Initialisation des stats du Set character type
        _playerMouvement = GetComponent<PlayerMouvement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
