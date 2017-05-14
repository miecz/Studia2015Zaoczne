using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour {

    Animator anim;
    float hor;
    float ver;
    public float rotationSpeed = 90f;
    public float moveSpeed = 2f;

	void Start () {
        anim = GetComponent<Animator>();
        anim.applyRootMotion = false;
	}
	void Update () {

        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        anim.SetFloat("Speed", ver);

        transform.Rotate(Vector3.up, rotationSpeed * hor * Time.deltaTime, Space.World);
        transform.Translate(transform.forward * moveSpeed * ver * Time.deltaTime, Space.World);
	}
}
