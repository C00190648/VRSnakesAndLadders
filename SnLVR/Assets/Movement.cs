using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

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

    // Use this for initialization
    void Start()
    {
        // Find the CharacterController
        controller = GetComponent<CharacterController>();
        // Find the GvrViewer on child 0
        gvrViewer = transform.GetChild(0).GetComponent<GvrEditorEmulator>();
        // Fnd the VR Head
        vrHead = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GvrPointerPhysicsRaycaster.cc.hit);
        Debug.Log("nice");
        //GvrPointerPhysicsRaycaster.cc.hit = false;

        // In the Google VR button press
        if (Input.GetButtonDown("Fire1") && GvrPointerPhysicsRaycaster.cc.hit == false)
        {
            // Change the state of moveForward
           // moveForward = !moveForward;
            Debug.Log("no hit");
        }
        else
        {
            Debug.Log("HIT");
        }

        // Check to see if I should move
        if (Input.GetButton("Fire1"))
        {
            // Find the forward direction
            Vector3 forward = vrHead.TransformDirection(Vector3.forward);
            // Tell CharacterController to move forward
            controller.SimpleMove(forward * speed);
        }
    }
}
