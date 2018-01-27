using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float health;

    public void TakeDamage(float damage)
    {
        health -= damage;
        CheckDeath();
    }

    private void CheckDeath()
    {
        if (health > 0f)
        {
            return;
        }
        else
        {
            Debug.Log(this.name + " is dead.");
            Destroy(gameObject);
        }
    }
}
