using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerTurnOnSound : MonoBehaviour
{

    public AudioClip soundClip;
    AudioSource soundSource;

    // Use this for initialization
    void Start()
    {
        soundSource = GetComponent<AudioSource>();
    }



    private void OnTriggerEnter(Collider other)
    {

        if (soundClip != null)
        {
            if(!soundSource.isPlaying)
            soundSource.PlayOneShot(soundClip, 0.75f);
            
            
        }


    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            soundSource.Play();
        }
        */
    }
}
