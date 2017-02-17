﻿// Credit to damien_oconnell from http://forum.unity3d.com/threads/39513-Click-drag-camera-movement
// for using the mouse displacement for calculating the amount of camera movement and panning code.
// Credit to JISyed https://gist.github.com/JISyed/5017805 for this the camera movement code

using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{
    //
    // VARIABLES
    //

    public float turnSpeed = 4.0f;      // Speed of camera turning when mouse moves in along an axis
    public float panSpeed = 4.0f;       // Speed of the camera when being panned
    public float zoomSpeed = 4.0f;      // Speed of the camera going back and forth

    public Transform ragdoll;       // Follow the ragdoll
    
    private Vector3 mouseOrigin;    // Position of cursor when mouse dragging starts
    private bool isPanning;     // Is the camera being panned?
    private bool isRotating;    // Is the camera being rotated?
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Get the left mouse button
        if (Input.GetMouseButtonDown(1))
        {
            // Get mouse origin
            mouseOrigin = Input.mousePosition;
            isRotating = true;
        }

        // Get the right mouse button
        if (Input.GetMouseButtonDown(0))
        {
            // Get mouse origin
            mouseOrigin = Input.mousePosition;
            isPanning = true;
        }

        // Disable movements on button release
        if (!Input.GetMouseButton(1)) isRotating = false;
        if (!Input.GetMouseButton(0)) isPanning = false;

        // Rotate camera along X and Y axis
        if (isRotating)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed);
            transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed);
        }

        // Move the camera on it's XY plane
        //if (isPanning)
        //{
        //    //Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

        //    //Vector3 move = new Vector3(pos.x * panSpeed, pos.y + 1.5f * panSpeed, 0);
        //    //transform.Translate(move, Space.Self);
        //}

        Vector3 ragdollPos = new Vector3(ragdoll.position.x, ragdoll.position.y + 1.5f, ragdoll.position.z + 3.0f);
        //transform.Translate(move, Space.Self);
        transform.position = ragdollPos;


        // Zoom in and out with the mouse
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(transform.forward * scrollWheel, Space.World);
    }
}