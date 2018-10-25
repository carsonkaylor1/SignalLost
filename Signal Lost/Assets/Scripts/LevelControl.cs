using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour {

    public int index;
    public string levelName;

	// Use this for initialization
	void OnTriggerEnter (Collider other) {
        if (other.CompareTag("Player"))
        {
           //SceneManager.LoadScene(1);

           SceneManager.LoadScene(levelName);
        }
		
	}
	
}
