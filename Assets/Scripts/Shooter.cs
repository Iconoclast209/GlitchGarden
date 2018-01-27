using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;
    private GameObject projectileParent;
    private Animator anim;
    private AttackerSpawner myLaneSpawner;

    void Start()
    {
        anim = GetComponent<Animator>();
        SetMyLaneSpawner();
        projectileParent = GameObject.Find("ProjectileParent");
        if (!projectileParent)
        {
            projectileParent = new GameObject("ProjectileParent");
            projectileParent.transform.position = new Vector3(0, 0, 0);

        }
    }

    void Update()
    {
        //If there is an attacker in the lane, set attack state
        if (IsAttackerAheadInLane())
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
    }

    private void FireGun()
    {
        GameObject newProjectile = Instantiate(projectile);
        Debug.Log(newProjectile.name + " has been instantiated.");
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
    
    bool IsAttackerAheadInLane()
    {
        if(myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            //Create an array of the attackers in the lane.
            Attacker[] attackersInLane = myLaneSpawner.GetComponentsInChildren<Attacker>();
            //Check each to see if the X position is greater than transform.position.x
            foreach(Attacker currentAttacker in attackersInLane)
            {
                if(currentAttacker.gameObject.transform.position.x > transform.position.x)
                {
                    return true;
                }
            }
            return false;
        }    
        
    }

    void SetMyLaneSpawner()
    {
        //Look through all spawners and set myLaneSpawner if found.
        AttackerSpawner[] attackerSpawnerArray = GameObject.FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner myAS in attackerSpawnerArray)
        {
            if(myAS.gameObject.transform.position.y == transform.position.y)
            {
                myLaneSpawner = myAS;
                print(myLaneSpawner.ToString() + " has been set as myLaneSpawner.");
                return;
            }
        }
        Debug.LogError("Unable to Locate Attacker Spawner in Lane " + transform.position.y.ToString());
       
    }
}
