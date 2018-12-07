using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup2 : MonoBehaviour {


    public GameObject myWeapon;
    public GameObject weaponOnGround;
    public Transform player;
    public GameObject gobject;
    // Use this for initialization
    bool t = false;
    private void OnTriggerEnter(Collider _collider)
    {
        if (_collider.gameObject.tag == "Player")
        {
            t = true;
            gobject.transform.position = player.position;
            //myWeapon.SetActive(true);
           // weaponOnGround.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update () {
        if (t == true)
        {
            gobject.transform.position = player.position;
        }
	}
}
