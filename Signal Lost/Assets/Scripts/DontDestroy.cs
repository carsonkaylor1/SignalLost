using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

   // public 

   // int playerCount = GameObject.FindGameObjectsWithTag("Player");

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        if(GameObject.FindGameObjectsWithTag("Player").Length > 1)
        {
            Destroy(gameObject);
        }
    }
}
