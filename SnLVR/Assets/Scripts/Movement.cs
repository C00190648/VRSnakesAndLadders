﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    // How fast to move
    public float speed = 5.0F;
    // Should I move forward or not
    public bool moveForward;

    // GvrViewer Script
    private GvrEditorEmulator gvrViewer;
    // VR Head
    private Transform vrHead;

    public static Movement playerMove;


    public bool canMoveOnClick;

    public bool moveUp;

    public bool moveBack;

    float gravity = 18.81f;

    // Use this for initialization
    void Start()
    {
        // Find the GvrViewer on child 0
        gvrViewer = transform.GetChild(0).GetComponent<GvrEditorEmulator>();
        // Fnd the VR Head
        vrHead = Camera.main.transform;

        playerMove = this;

        moveUp = false;
        moveBack = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (vrHead.eulerAngles.x > 30 && vrHead.eulerAngles.x < 90)
        {
            Debug.Log("forward");
            moveForward = true;
            moveBack = false;
        }
        else if (vrHead.eulerAngles.x < 340 && vrHead.eulerAngles.x > 310)
        {
            Debug.Log("backward");
            moveBack = true;
            moveForward = false;
        }
        else
        {
            moveForward = false;
            moveBack = false;

            //Audio for when the player walks
            GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().loop = true;
        }

        // Check to see if I should move
        if (moveForward && !moveUp)
        {
            // Find the forward direction
            Vector3 forward = vrHead.TransformDirection(Vector3.forward);
            // Tell Character to move forward
            transform.Translate(forward * speed * Time.deltaTime);
        }

        if (moveBack && !moveUp)
        {
            // Find the forward direction
            Vector3 forward = vrHead.TransformDirection(Vector3.forward);
            // Tell Character to move back
            transform.Translate(forward * -speed * Time.deltaTime);
        }

        if (moveUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }

        if (!moveUp)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }

    }

}