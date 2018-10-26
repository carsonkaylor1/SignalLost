using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //Most of this is reused from the in class example

    float velX, velY;
    float X, Y;

    public float maxVel;

    public float mouseSpeed = 3;

    Rigidbody rigid;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        X = Input.GetAxis("Mouse X") * mouseSpeed;
        Y = Input.GetAxis("Mouse Y") * mouseSpeed;

        transform.Rotate(0, X, 0);

        velX = Input.GetAxis("Horizontal");
        velY = Input.GetAxis("Vertical");

        if(Input.GetButton("Horizontal"))
        {

        }
        Vector3 forwardVel = transform.forward * maxVel * -velX;
        Vector3 horizontalVel = transform.right * maxVel * velY;
        Vector3 sumVel = forwardVel + horizontalVel;

        sumVel.y = rigid.velocity.y;

        rigid.velocity = sumVel;

    }

}
