using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    private Camera cam;
    private GameObject parent;
    private StarDisplay starDisplay;

	// Use this for initialization
	void Start ()
    {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
        cam = GameObject.Find("GameCamera").GetComponent<Camera>();
        parent = GameObject.Find("DefenderParent");
        if (!parent)
        {
            parent = new GameObject("DefenderParent");
            parent.transform.position = new Vector3(0, 0, 0);
        }
    }
	
	private void OnMouseDown()
    {
        if(Button.selectedDefender)
        {
            //If you have enough stars to place a defender, place the defender.
            if(starDisplay.UseStars(Button.selectedDefender.GetComponent<Defender>().starCost) == StarDisplay.Status.SUCCESS)
            {
                Vector2 pos = SnapToGrid(CalculateWorldPointOfMouseClick(Input.mousePosition.x, Input.mousePosition.y));
                GameObject newDefender = Instantiate(Button.selectedDefender, pos, Quaternion.identity);
                newDefender.transform.parent = parent.transform;
            }
            else
            {
                Debug.Log("Insufficient Stars to Spawn");
            }
            
        }
        
    }

    private Vector2 CalculateWorldPointOfMouseClick(float x, float y)
    {
        Vector2 worldPos = cam.ScreenToWorldPoint(new Vector3(x, y, 0));
        return worldPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        int intX = Mathf.RoundToInt(rawWorldPos.x);
        int intY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(intX, intY);
    }

}




