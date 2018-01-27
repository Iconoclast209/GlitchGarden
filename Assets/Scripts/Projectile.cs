using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float projectileSpeed;
    public float projectileDamage;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveRight();
	}
    
    void MoveRight()
    {
        transform.Translate(Vector3.right * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(this.name + " collided with " + other);
        GameObject obj = other.gameObject;

        //Test to see if the collision is with an attacker.  If it is not, ignore it.
        if (!obj.GetComponent<Attacker>())
        {
            return;
        }

        // If it is an Attacker, deal damage
        Health enemyHealth = obj.GetComponent<Health>();
        enemyHealth.TakeDamage(projectileDamage);

        //Then Destroy the Projectile
        Destroy(gameObject);
        
    }


}
