using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    [Tooltip ("Average time between appearances")]
    public float seenEverySeconds;
    private float currentSpeed;
    private GameObject currentTarget;
    private Animator animator;


	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveLeft();
        if(!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }
	}

    void MoveLeft()
    {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    // Called from Animator at time of the attack
    public void StrikeCurrentTarget(float damage)
    {
        
        if(!currentTarget)
        {
            Debug.LogError(this.name + " attempted to deal damage to a invalid target.");
        }
        else
        {
            Health targetHealth = currentTarget.GetComponent<Health>();
            targetHealth.TakeDamage(damage);
        }
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }

    public float GetSeenEverySeconds()
    {
        return seenEverySeconds;
    }

}
