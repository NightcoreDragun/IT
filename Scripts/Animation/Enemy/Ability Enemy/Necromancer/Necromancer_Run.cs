using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necromancer_Run : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 0.7f;
    public float attackRangeY = 0.2f;

    Transform player;
    Rigidbody2D rb;
    LookAtPlayer enemy;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<LookAtPlayer>();  
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();

    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    ///Bouge l'enemy ver le joueur et le fait regarde dans ca direction
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.LookAtThe();
        if (Mathf.Abs(player.position.x - rb.position.x) <= attackRange && Mathf.Abs(player.position.y - rb.position.y) <= attackRangeY)
        {
                animator.SetTrigger("Attack");
        }
        else
        {
            Vector2 target = new Vector2(player.position.x, player.position.y);
            Vector2 newPostition = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPostition);
        }
      

        
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }



    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
