using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSound : MonoBehaviour {

    //public AudioClip soundClip;
    public AudioSource soundSource;
    private float fadeOutTime = 1;
    // Use this for initialization
    void Start () {
        //soundSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            if (!soundSource.isPlaying)
                soundSource.Play();
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (!soundSource.isPlaying)
                soundSource.Play();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            soundSource.Stop();
            
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            soundSource.Stop();
        }
        //soundSource.volume = 0.25f;
     
    }
}
