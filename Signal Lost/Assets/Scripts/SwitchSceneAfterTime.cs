using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;


//Place script on other object, not rover
public class SwitchSceneAfterTime : MonoBehaviour {

    public float delay;
    public string newLevel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //Make sure rover has Player tag
        {
            StartCoroutine(LoadLevelAfterDelay(delay));
        }
    }
    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(newLevel);
    }


}
