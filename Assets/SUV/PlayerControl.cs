using UnityEngine;
using System.Collections;

public class PlayerControl: MonoBehaviour
{

    public WheelCollider FrontLeft;
    public WheelCollider FrontRight;
    public WheelCollider RearRight;
    public WheelCollider RearLeft;

    float speed = 30.0f;
    float braking = 20.0f;
    float turning = 20.0f;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = new Vector3(0, -1, 0);
       // rigidbody.centerOfMass = new Vector3(0, -1, 0);
    }

    // Update is called once per frame
    void Update()
     {

        //this code makes car go forward
        if (Input.GetKey(KeyCode.A))
        {
            RearRight.motorTorque = Input.GetAxis("Vertical") * speed;
            RearLeft.motorTorque = Input.GetAxis("Vertical") * speed;
        }

        if (Input.GetKey("up"))
        {
            //Debug.Log("up painettu");
            RearRight.motorTorque = Input.GetAxis("Vertical") * speed;
            RearLeft.motorTorque = Input.GetAxis("Vertical") * speed;

            //Debug.Log("Vääntö: " + RearRight.motorTorque);

        }


        //this code is for turning
        if (Input.GetKey("right"))
          {
              FrontRight.steerAngle = Input.GetAxis("Horizontal") * turning;
              FrontLeft.steerAngle = Input.GetAxis("Horizontal") * turning;
          }

          if (Input.GetKey("left"))
          {
              FrontRight.steerAngle = Input.GetAxis("Horizontal") * turning;
              FrontLeft.steerAngle = Input.GetAxis("Horizontal") * turning;
          }

          //Breaking
          if (Input.GetKey("down"))
          {
              RearRight.brakeTorque = braking;
              RearLeft.brakeTorque = braking;
          }

        RearRight.brakeTorque = 0;
        RearLeft.brakeTorque = 0;

    }

}