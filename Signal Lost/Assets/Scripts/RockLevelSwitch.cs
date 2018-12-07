using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RockLevelSwitch : MonoBehaviour {

    public static int rockCount = 0;
    public string levelName;
    GameObject rocks;
    Text rockUI;

    private void Start() 
    {
        rocks = GameObject.Find("rockUI");
        rockUI = rocks.GetComponent<Text>();
        rockUI.text = "Rock Samples Collected: " + rockCount + "/5";
    }
  

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rock")) //tag all rock objects as "Rock" so rover can pick up rock
        {
            rockCount += 1;
            other.gameObject.SetActive(false); //rock disappears
            rockUI.text = "Rock Samples Collected: " + rockCount + "/5";
        }
        
        if (rockCount >= 6) //Loads a new scene when rock count is >= 2
        {
            rockUI.enabled = false;
            SceneManager.LoadScene(levelName);
        }
    }

}
