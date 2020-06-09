using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_phone_input_player_controller : MonoBehaviour
{
    public float speed = 30f;
    private new Rigidbody rigidbody;

    
    private Vector3 lastPos;
    private Vector3 currentPos;
    bool isMoving;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        Debug.Log("RB accessed");

       
    }


    void FixedUpdate()
    {

        currentPos = transform.position;

        //rotates the character based on the direction the phone is tilted towards
        // creates the target rotation based on the phone's x and y position
     
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(Input.acceleration.x, 0, Input.acceleration.y));
        // creates a slerp between the target rotation and current rotation. Might speed it up later, have a variable ready to do so.
        Quaternion moveRotation = Quaternion.Slerp(rigidbody.rotation, targetRotation, Time.fixedDeltaTime);

        rigidbody.MoveRotation(moveRotation);
        Debug.Log("I am spinning");

        //creates a magnitude based speed variable so that the character moves faster at higher phone angles
        //creates a vector between the xpos input and ypos input
        Vector2 Magnitude = new Vector2(Input.acceleration.x, Input.acceleration.y);
        //set magnitude vector to an absolute float value
        float speedMultiplier = Mathf.Abs(Magnitude.magnitude);


       

       

        rigidbody.AddForce( transform.forward * speed *speedMultiplier);
        Debug.Log("Ice is slippery!");

        if(currentPos != lastPos)
        {
            isMoving = true;
            Debug.Log("real slippery!");
        }
        else
        {
            isMoving = false;
            
            //Invoke("Respawn", 5f);
        }

        lastPos = currentPos;

    }

    void Respawn (Vector3 checkpoint)
    {
        rigidbody.position = checkpoint;
    }
}
