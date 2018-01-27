using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PanelFade : MonoBehaviour {

    public float fadeInTime;
    
    private Image image;
    private Color currentColor = Color.black;

	// Use this for initialization
	private void Start ()
    {
        image = GetComponent<Image>();
	}

    private void Update()
    {
        if (Time.timeSinceLevelLoad < fadeInTime)
        {
            float alphaChange = Time.deltaTime / fadeInTime;
            currentColor.a -= alphaChange;
            image.color = currentColor;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
