using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveToGame : MonoBehaviour {

	public int delay;

    void Awake()
	{
		StartCoroutine(LoadLevelAfterDelay(delay));
	}

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
