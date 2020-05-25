using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_camera_follow : MonoBehaviour
{

    public Transform PlayerTransform;
    //access player's position

    private Vector3 _cameraOffset;
    //access offset of camera compared to player

    [Range(0.01f, 1.0f)]
    public float Smoothing = 0.5f;
    //smooths camera following movement

    // Start is called before the first frame update
    void Start()
    {
        _cameraOffset = transform.position - PlayerTransform.position;
        //assigns fixed offset of camera based on awake position
    }

    // Update is called once per frame
    void LateUpdate()
    // instructs camera to follow with offset and lerp between current and new position for smooth movement
    {
        Vector3 newPos = PlayerTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, Smoothing);
    }
}
