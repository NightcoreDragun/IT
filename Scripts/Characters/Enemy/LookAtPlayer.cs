/* Palalau Alexandru
 * 06.05.2022
 * Change the object orientation towards the player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class LookAtPlayer : MonoBehaviour
{
	private Transform player;
	private bool isFlipped = false;
    
    private void Start()
    {
        //Trouve le jouer avec le tag Player
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	/// <summary>
	/// Flip the sprite of the object toward the player (to use if the object have only 1 sprite direction)
	/// </summary>
	public void LookAtThe()
	{
		Vector2 flipped = transform.localScale;
		if (transform.position.x < player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;

		}
		else if (transform.position.x > player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;

		}
	}
}
