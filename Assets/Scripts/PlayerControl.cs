﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour
{
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have

    public int iGasPumps = 0;

    public float speed;
    public float maxSpeed = 150;

    //GUI Texture for dial
    public Texture2D speedOMeterDial;
    public Texture2D speedOMeterPointer;

    int minAnglePointer = -90;
    int maxAnglePointer = 180;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Application.LoadLevel(0);

        }
    }



    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        Rigidbody rb;
        rb = GetComponent<Rigidbody>();
        speed = rb.angularVelocity.magnitude * 3.6f * 2; //rigidbody.velocity.magnitude * 3.6f;
        if (speed > maxSpeed)
        {
            motor = 0;
        }


        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Moorgaas")
        {
            //Debug.Log("Etappi");
            other.gameObject.SetActive(false);
            iGasPumps = iGasPumps + 1;

            if (iGasPumps == 4)
            {
                Application.LoadLevel("Scene2");
            }
            if (iGasPumps == 8)
            {
                Application.LoadLevel("Scene3");
            }
        }
    }

    void OnGUI()
    {
        Rect rect = new Rect(0, Screen.height - 200, 200, 200);



        //Rect rect = new Rect(10,10, 200, 200);


        if (Event.current.type.Equals(EventType.Repaint))
        {
            speedOMeterDial.alphaIsTransparency = true;
            speedOMeterPointer.alphaIsTransparency = true;
            Graphics.DrawTexture(rect, speedOMeterDial);
            // Graphics.DrawTexture(rect, speedOMeterDial);

            float speedFactor = speed / maxSpeed;
            float rotationAngle;
            if (speed >= 0)
            {
                rotationAngle = Mathf.Lerp(minAnglePointer, maxAnglePointer, speedFactor);
            }
            else
            {
                rotationAngle = Mathf.Lerp(minAnglePointer, maxAnglePointer, -speedFactor);
            }

            Vector2 vector2 = new Vector2(100, Screen.height - 100);
            GUIUtility.RotateAroundPivot(rotationAngle, vector2);

            Rect rect2 = new Rect(0, Screen.height - 200, 200, 200);
            Graphics.DrawTexture(rect2, speedOMeterPointer);

        }
    }

}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool steering; // does this wheel apply steer angle?
    public bool motor; // is this wheel attached to motor?
}
