using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverMovement : MonoBehaviour {

    public int spinx;
    public int spiny;
    public int spinz;

    public GameObject FL;
    public GameObject FR;
    public GameObject ML;
    public GameObject MR;
    public GameObject BL;
    public GameObject BR;

    public WheelCollider C_FL;
    public WheelCollider C_FR;
    public WheelCollider C_ML;
    public WheelCollider C_MR;
    public WheelCollider C_BL;
    public WheelCollider C_BR;

    public float Torque = 1000f;

    public float lowestSteerSpeed;
    public float lowestSteerAngle;
    public float highestSteerAngle;

    public float mouseSpeed = 3;
    float X, Y, Z;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        movement();
        rotateWheels();
        steerWheels();
        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            Spin();
        }
    }

    void movement()
    {
        C_ML.motorTorque = Torque * Input.GetAxis("Vertical");
        C_ML.motorTorque = Torque * Input.GetAxis("Vertical");

        float speedfactor = this.GetComponent<Rigidbody>().velocity.magnitude / lowestSteerSpeed;
        float currentSteerAngle = Mathf.Lerp(lowestSteerAngle, highestSteerAngle, speedfactor);

        currentSteerAngle *= Input.GetAxis("Horizontal");

        C_BL.steerAngle = currentSteerAngle + 90;
        C_BR.steerAngle = currentSteerAngle - 90;

        C_ML.steerAngle = currentSteerAngle + 90;
        C_MR.steerAngle = currentSteerAngle - 90;

    }

    void rotateWheels()
    {
       // ML.gameObject.transform.Rotate(0, 0, C_ML.rpm / 60 * 360 * Time.deltaTime);
       // MR.gameObject.transform.Rotate(0, 0, C_MR.rpm / 60 * 360 * Time.deltaTime);
    }

    void Spin()
    {
        ML.gameObject.transform.Rotate(spinx, spiny, spinz);
        MR.gameObject.transform.Rotate(spinx, spiny, -spinz);
        BL.gameObject.transform.Rotate(spinx, spiny, spinz);
        BR.gameObject.transform.Rotate(spinx, spiny, -spinz);
    }

    void steerWheels()
    {
        /*
        X = Input.GetAxis("Mouse X") * mouseSpeed;
        Y = Input.GetAxis("Mouse Y") * mouseSpeed;

        BL.gameObject.transform.Rotate(X, 0, 0);
        BR.gameObject.transform.Rotate(X, 0, 0);
        */

        Vector3 temp;
        temp = BL.transform.localEulerAngles;
        temp.y = -C_BL.steerAngle;
        BL.transform.localEulerAngles = temp;

        temp = BR.transform.localEulerAngles;
        temp.y = -C_BR.steerAngle;
        BR.transform.localEulerAngles = temp;

        temp = ML.transform.localEulerAngles;
        temp.y = -C_ML.steerAngle;
        ML.transform.localEulerAngles = temp;

        temp = MR.transform.localEulerAngles;
        temp.y = -C_MR.steerAngle;
        MR.transform.localEulerAngles = temp;
    }
}
