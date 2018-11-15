using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RockLevelSwitch : MonoBehaviour {

    public static int rockCount = 0;
    public string levelName;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rock")) //tag all rock objects as "Rock" so rover can pick up rock
        {
            rockCount += 1;
            other.gameObject.SetActive(false); //rock disappears
        }
        
        if (rockCount >= 6) //Loads a new scene when rock count is >= 2
        {
            SceneManager.LoadScene(levelName);
        }
    }

}
