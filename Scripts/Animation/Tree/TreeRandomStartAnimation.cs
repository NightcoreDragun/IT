using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeRandomStartAnimation : MonoBehaviour
{
    Animator anim;
    AnimatorStateInfo state;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        state = anim.GetCurrentAnimatorStateInfo(0);

        //Starts the animation of tree at a random frame.
        anim.Play(state.fullPathHash, -1, Random.Range(0f, 1f));
    }

}
