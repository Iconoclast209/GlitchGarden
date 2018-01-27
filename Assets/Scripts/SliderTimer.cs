using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimer : MonoBehaviour {

    public float levelLengthInSeconds=60f;
    public LevelManager levelManager;
    private Slider slider;
    private AudioSource audioSource;
    private float timeRemaining;
    private GameObject winLabel;
    private bool levelOver=false;
    

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
        winLabel = GameObject.Find("YouWin");
        if(!winLabel)
        {
            Debug.LogWarning("Cannot find You Win object");
        }
        winLabel.SetActive(false);
        slider.maxValue = levelLengthInSeconds;
        timeRemaining = levelLengthInSeconds;
	}

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        slider.value = timeRemaining;

        if (timeRemaining <= 0 && !levelOver)
        {
            audioSource.Play();
            levelOver = true;
            winLabel.SetActive(true);
            Invoke("LoadNextLevel", audioSource.clip.length);
        }
    }

    void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }
}
