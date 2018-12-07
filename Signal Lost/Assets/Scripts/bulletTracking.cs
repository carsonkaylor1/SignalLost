using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletTracking : MonoBehaviour {

    private float MoveSpeed = 1.5f;

    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void onTriggerEnter(Collider other)
    {
        string objectName = other.name;
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("turret"))
        {
            transform.LookAt(other.transform);
            rigid.transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
    }

}
