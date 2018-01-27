using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour {

    public enum Status { SUCCESS, FAILURE};
    private Text display;
    private int starCount = 100;

    private void Start()
    {
        display = GetComponent<Text>();
        UpdateStarDisplay();
    }

    public void AddStars(int amount)
    {
        starCount += amount;
        UpdateStarDisplay();
    }

    public Status UseStars(int amount)
    {
        if(amount <= starCount)
        {
            starCount -= amount;
            UpdateStarDisplay();
            return Status.SUCCESS;
        }
        else
        {
            return Status.FAILURE;
        }
        
    }

    private void UpdateStarDisplay()
    {
        display.text = starCount.ToString();
    }

}
