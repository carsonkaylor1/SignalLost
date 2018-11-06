using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //Most of this is reused from the in class example

    float velX, velY, velZ;
    float X, Y, Z;

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
        Z = 0;

        transform.Rotate(0, X, 0);

        velX = Input.GetAxis("Horizontal");
        velY = Input.GetAxis("Vertical");

        if (Input.GetKey("space"))
        {
            float jumpSpeed = 100.0f;
            rigid.AddForce(Vector3.up * jumpSpeed);
        }

        Vector3 verticalVel = transform.up * maxVel * velZ;
        Vector3 forwardVel = transform.forward * maxVel * -velX;
        Vector3 horizontalVel = transform.right * maxVel * velY;
        Vector3 sumVel = forwardVel + horizontalVel;

        sumVel.y = rigid.velocity.y;

        rigid.velocity = sumVel;

    }

}
