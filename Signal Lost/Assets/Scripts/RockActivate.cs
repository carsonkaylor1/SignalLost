using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockActivate : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter (Collider other) {

        if(other.gameObject.CompareTag("BlockRock"))

        if (RockLevelSwitch.rockCount > 2)
        {
                other.gameObject.SetActive(false);
        }
	}
}
