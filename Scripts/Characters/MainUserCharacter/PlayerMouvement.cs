/*
 * Palalau Alexandru
 * allows to manage the movement of a player and his animations
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInteraction))]
public class PlayerMouvement : MonoBehaviour
{
    private Rigidbody2D _playerRigidBody;
    private Vector2 _mouvement;
    public Characters character;
    public Animator animator;
    void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody2D>();
        _playerRigidBody.gravityScale = 0;
        _playerRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;

    }

    // Update is called once per frame
    void Update()
    {
        _mouvement.x = Input.GetAxisRaw("Horizontal");
        _mouvement.y = Input.GetAxisRaw("Vertical");
        if (_mouvement != Vector2.zero)
        {
            animator.SetFloat("Horizontal", _mouvement.x);
            animator.SetFloat("Vertical", _mouvement.y);
            animator.SetFloat("Speed", _mouvement.sqrMagnitude);
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
   

    }
    private void FixedUpdate()
    {
        MoveCharacter();
    }

    void MoveCharacter() 
    {
        _playerRigidBody.MovePosition(_playerRigidBody.position + character.mouvementSpeed * Time.fixedDeltaTime * _mouvement);
    }
}
