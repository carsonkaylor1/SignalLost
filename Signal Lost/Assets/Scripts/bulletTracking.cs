using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletTracking : MonoBehaviour {

    private float MoveSpeed = 1.5f;

    Rigidbody rigid;

    void Start()
    {
        print("rigid init");
        rigid = GetComponent<Rigidbody>();
    }

    private void onTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("turret"))
        {
            transform.LookAt(other.transform);
            print("yay");
            rigid.transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
    }

}
