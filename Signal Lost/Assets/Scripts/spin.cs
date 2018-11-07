using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour {

    public int spinx = 0;
    public int spiny = 0;
    public int spinz = 0;
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Horizontal"))
        {
            Spin();
        }


        
;	}

    void Spin()
    {
        transform.Rotate(spinx, spiny, spinz);
    }
}
