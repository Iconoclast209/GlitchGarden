using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garden : MonoBehaviour {

    public LevelManager levelManager;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(otherCollider.gameObject.GetComponent<Attacker>())
        {
            levelManager.LoadLevel("03BLose");
        }
    }
}
