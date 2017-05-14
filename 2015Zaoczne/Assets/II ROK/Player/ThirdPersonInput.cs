using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonInput : MonoBehaviour {
    float hor;
    float ver;
    public Camera movementCam;
    MovementBase movement;
    Vector3 cameraForward;
    Vector3 cameraRight;
    // Use this for initialization
    void Start () {
        if (movementCam == null)
        {
            GameObject go = GameObject.FindGameObjectWithTag("Main Camera");
            movementCam = go.GetComponent<Camera>();
        }
        movement = GetComponent<MovementBase>();
	}
	// Update is called once per frame
	void Update () {

        if (movementCam != null)
        {
            cameraForward = movementCam.transform.forward;
            cameraForward.y = 0f;
            cameraForward = cameraForward.normalized;

            cameraRight = movementCam.transform.right;
            cameraRight.y = 0f;
            cameraRight = cameraRight.normalized;
        }

        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            movement.jump = true;
        }

        movement.isRunning = Input.GetButton("Run");

        cameraRight = cameraRight * hor;
        cameraForward = cameraForward * ver;

        Debug.DrawLine(transform.position, transform.position + (cameraForward + cameraRight).normalized, Color.green);

        movement.desiredMovement = (cameraForward + cameraRight).normalized;
	}
}
