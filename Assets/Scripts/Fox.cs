using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Attacker))]
public class Fox : MonoBehaviour {

    private Attacker attacker;
    private Animator animator;

    private void Start()
    {
        attacker = GetComponent<Attacker>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(this.name + " collided with " + collider);
        GameObject obj = collider.gameObject;
        
        if (!obj.GetComponent<Defender>())
        {
            return;
        }

        if(obj.GetComponent<Blocker>())
        {
            // Jump
            animator.SetTrigger("foxJumpTrigger");
        }
        else
        {
            //Attack
            animator.SetBool("isAttacking", true);
            attacker.Attack(obj);
        }
    }

}
