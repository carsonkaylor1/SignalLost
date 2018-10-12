using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour {

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();	
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up")) //create a tag (under the name of an object) and set all pickups to Pick Up
        {
            other.gameObject.SetActive(false);
            //Depending on which pickup was picked up, do something.
        }
    }
}
