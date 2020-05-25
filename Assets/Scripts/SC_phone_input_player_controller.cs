using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_phone_input_player_controller : MonoBehaviour
{
    public float speed;
    private new Rigidbody rigidbody;

    float xPos = Input.acceleration.y;
    float yPos = Input.acceleration.x;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        Debug.Log("RB accessed");
        

    }
    private void Update()
    {

        //creates a magnitude based speed variable so that the character moves faster at higher phone angles
        //creates a vector between the xpos input and ypos input
        Vector2 Magnitude = new Vector2(xPos, yPos);
        //set magnitude vector to an absolute float value
        float speedMultiplier = Mathf.Abs(Magnitude.magnitude);


        speed = 15f * speedMultiplier;
    }

    void FixedUpdate()
    {
        //rotates the character based on the direction the phone is tilted towards
        // creates the target rotation based on the phone's x and y position
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(xPos, 0, yPos));
        // creates a slerp between the target rotation and current rotation. Might speed it up later, have a variable ready to do so.
        Quaternion moveRotation = Quaternion.Slerp(rigidbody.rotation, targetRotation, Time.fixedDeltaTime);

        rigidbody.MoveRotation(moveRotation);

        rigidbody.AddForce(transform.forward * speed);

    }
}
