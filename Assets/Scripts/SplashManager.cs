using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SplashManager : MonoBehaviour {

    public float startDelay;

	// Use this for initialization
	void Start () {
        Invoke("LoadStartLevel", startDelay);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadStartLevel()
    {
        SceneManager.LoadScene(1);
    }

}
