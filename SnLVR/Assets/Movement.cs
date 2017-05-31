using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    // How fast to move
    public float speed = 3.0F;
    // Should I move forward or not
    public bool moveForward;
    // CharacterController script
    private CharacterController controller;
    // GvrViewer Script
    private GvrEditorEmulator gvrViewer;
    // VR Head
    private Transform vrHead;

    public static Movement playerMove;


    public bool canMoveOnClick;

    public bool moveUp;

    float gravity = 9.81f;

    // Use this for initialization
    void Start()
    {
        // Find the CharacterController
        controller = GetComponent<CharacterController>();
        // Find the GvrViewer on child 0
        gvrViewer = transform.GetChild(0).GetComponent<GvrEditorEmulator>();
        // Fnd the VR Head
        vrHead = Camera.main.transform;

        playerMove = this;

        moveUp = false;

    }

    // Update is called once per frame
    void Update()
    {


        // In the Google VR button press
        if (Input.GetButtonDown("Fire1") && canMoveOnClick)
        {
            // Change the state of moveForward
            moveForward = !moveForward;
        }

        // Check to see if I should move
        if (moveForward && !moveUp)
        {
            // Find the forward direction
            Vector3 forward = vrHead.TransformDirection(Vector3.forward);
            // Tell CharacterController to move forward
            controller.SimpleMove(forward * speed);
        }

        if (!moveUp)
        {
            controller.SimpleMove(Vector3.down * gravity * Time.deltaTime);
        }

        if (moveUp && vrHead.eulerAngles.x < 320 && moveForward)
        {
            controller.Move(Vector3.up * speed * Time.deltaTime);

        }
    }

}