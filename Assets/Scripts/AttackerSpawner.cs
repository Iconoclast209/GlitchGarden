using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

    public GameObject[] attackerArray;
    private float timeSinceLastLizard, timeSinceLastFox = 0;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeSinceLastFox += Time.deltaTime;
        timeSinceLastLizard += Time.deltaTime;

        foreach (GameObject thisAttacker in attackerArray)
        {
            if (IsTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
        
            
    }

    void Spawn (GameObject obj)
    {
        Vector2 pos = transform.position;
        GameObject newAttacker = Instantiate(obj, pos, Quaternion.identity);
        newAttacker.transform.parent = transform;
        
        if(obj.GetComponent<Lizard>())
        {
            timeSinceLastLizard = 0;
        }
        else if(obj.GetComponent<Fox>())
        {
            timeSinceLastFox = 0;
        }
        
    }

    bool IsTimeToSpawn(GameObject attackerGameObject)
    {
        Attacker attacker = attackerGameObject.GetComponent<Attacker>();

        float meanSpawnDelay = attacker.seenEverySeconds;
        float spawnsPerSecond = 1 / meanSpawnDelay;

        if (Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("Spawn Rate Capped By Frame Rate.");
        }

        float threshold = spawnsPerSecond * Time.deltaTime;

        return (Random.value < threshold);
    }

}




/*bool IsTimeToSpawn(GameObject obj)
{
    float spawnDelay = obj.GetComponent<Attacker>().GetSeenEverySeconds();
    if(obj.GetComponent<Lizard>())
    {
        if(spawnDelay <= timeSinceLastLizard)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    else if (obj.GetComponent<Fox>())
    {
        if (spawnDelay <= timeSinceLastFox)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    else
    {
        Debug.LogError("IsTimeToSpawn() was passed an invalid attacker prefab object.");
        return false;
    }


}*/
