using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLevelStart : MonoBehaviour {

    private MusicManager musicManager;
    


	// Use this for initialization
	void Start () {
        musicManager = FindObjectOfType<MusicManager>();
        float volume = PlayerPrefsManager.GetMasterVolume();
        musicManager.ChangeVolume(volume);
            
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
