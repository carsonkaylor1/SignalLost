﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//place script on other object, not rover
public class LevelControl : MonoBehaviour {

    public int index;
    public string levelName;

    void OnTriggerEnter (Collider other) {
        if (other.CompareTag("Player"))
        {
           //SceneManager.LoadScene(1);

           SceneManager.LoadScene(levelName);
        }
		
	}
	
}
