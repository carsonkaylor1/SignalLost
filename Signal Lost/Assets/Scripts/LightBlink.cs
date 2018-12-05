using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlink : MonoBehaviour {
    public float timeOn;
    public float timeOff;
    private float changeTime = 1;
    public Light lightSource;
    public float timer = 1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Time.time > changeTime)
        {

            lightSource.enabled = !lightSource.enabled;
            if (lightSource.enabled)
            {
                changeTime = Time.time + timeOn;
            }
            else
            {
                changeTime = Time.time + timeOff;
            }
        }
	}
}
