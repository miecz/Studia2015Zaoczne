using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public Transform target;
    Vector3 toTargetVector;
    MovementBase movement;

	// Use this for initialization
	void Start () {
        movement = GetComponent<MovementBase>();
	}
	
	// Update is called once per frame
	void Update () {
        toTargetVector = target.position - transform.position;
        movement.desiredMovement = toTargetVector;

    }
}
