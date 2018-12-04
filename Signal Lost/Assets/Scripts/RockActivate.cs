using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockActivate : MonoBehaviour {

	//Script for the rock blocking pathway in underground scene
	void OnTriggerEnter (Collider other) {

        if(other.gameObject.CompareTag("BlockRock"))

        if (RockLevelSwitch.rockCount > 4)
        {
                other.gameObject.SetActive(false);
        }
	}
}
