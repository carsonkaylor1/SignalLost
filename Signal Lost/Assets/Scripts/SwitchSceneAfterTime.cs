using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class SwitchSceneAfterTime : MonoBehaviour {

    public int delay = 4;
    public string newLevel = "testEnvironment";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("computer"))
        {
            SceneManager.LoadScene(newLevel);
            // StartCoroutine(LoadLevelAfterDelay(delay));
        }
    }
   // IEnumerator LoadLevelAfterDelay(int delay)
   // {
    //    yield return new WaitForSeconds(delay);
    //    SceneManager.LoadScene(newLevel);
   // }


}
