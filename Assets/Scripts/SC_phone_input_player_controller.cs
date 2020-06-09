using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_phone_input_player_controller : MonoBehaviour
{
    public float speed = 20f;
    private new Rigidbody rigidbody;

    float xPos;
    float yPos;
    private Vector3 lastPos;
    bool isMoving;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        Debug.Log("RB accessed");

         xPos = Input.acceleration.y;
         yPos = Input.acceleration.x;

    }


    void FixedUpdate()
    {

        lastPos = transform.position;

        //rotates the character based on the direction the phone is tilted towards
        // creates the target rotation based on the phone's x and y position
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(xPos, 0, yPos));
        // creates a slerp between the target rotation and current rotation.
        Quaternion moveRotation = Quaternion.Slerp(rigidbody.rotation, targetRotation, Time.fixedDeltaTime);

        //creates a magnitude based speed variable so that the character moves faster at higher phone angles
        //creates a vector between the xpos input and ypos input
        Vector2 Magnitude = new Vector2(xPos, yPos);
        //set magnitude vector to an absolute float value
        float speedMultiplier = Mathf.Abs(Magnitude.magnitude);


        float movementSpeed = speed * speedMultiplier;

        rigidbody.MoveRotation(moveRotation);
        Debug.Log("I am spinning");

        rigidbody.AddForce(transform.position + transform.forward * movementSpeed);
        Debug.Log("Ice is slippery!");

        if(transform.position != lastPos)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
            Invoke("Respawn", 5f);
        }

    }

    void Respawn (Vector3 checkpoint)
    {
        rigidbody.position = checkpoint;
    }
}
