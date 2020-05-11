using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Accelerometer : MonoBehaviour
{
    public float speed;
    private new Rigidbody rigidbody;
    //private float rotationSpeed = 0.5f * Time.fixedDeltaTime;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        Debug.Log("RB accessed");
        

    }

    void FixedUpdate()
    {
       
       // creates the target rotation based on the phone's x and y rotation
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(Input.acceleration.y, 0, Input.acceleration.x));
        // creates a slerp between the target rotation and current rotation. Might speed it up later, have a variable ready to do so.
        Quaternion moveRotation = Quaternion.Slerp(rigidbody.rotation, targetRotation, Time.fixedDeltaTime);

        rigidbody.MoveRotation(moveRotation);
        Debug.Log("Am Spinning");

        Vector2 Magnitude = (Vector2)Input.acceleration;
        float speedMultiplier = Mathf.Abs(Magnitude.magnitude);
        speed = 10f * speedMultiplier;

        rigidbody.AddForce(transform.forward * speed);

        



    }
}
