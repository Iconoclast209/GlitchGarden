using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";

    public static void SetMasterVolume (float vol)
    {
        if (vol >= 0f && vol <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, vol);
        }
        else
        {
            Debug.LogError("Master Volume Too High to Set to PlayerPrefs");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(),1);  // Use 1 for True
        }
        else
        {
            Debug.LogError("Trying to unlock level " + level + " which does not exist in build settings");
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        
        if(level > SceneManager.sceneCountInBuildSettings - 1)
        {
            Debug.LogError("Trying to query level " + level + " which does not exist in build settings");
            return false;
        }
        else
        {
            string levelKey = LEVEL_KEY + level.ToString();
            if (PlayerPrefs.GetInt(levelKey) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
    }


    public static void SetDifficulty(float diff)
    {
        if (diff >= 1f && diff <= 3f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, diff);
        }
        else
        {
            Debug.LogError("Difficulty outside of 0 to 1 range.  Cannot set to PlayerPrefs");
        }
    }

    public static float GetDifficulty()
    {
        float diff = PlayerPrefs.GetFloat(DIFFICULTY_KEY);

        if(diff >= 1f && diff <= 3f)
        {
            return diff;
        }
        else
        {
            Debug.Log("No Valid Difficulty Setting Exists.");
            return 0f;
        }
    }

}
