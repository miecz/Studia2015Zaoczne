using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimDesync : MonoBehaviour {

    Animator anim;
    public float speedMin = 0.8f;
    public float speedMax = 1.2f;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        anim.speed = Random.Range(speedMin, speedMax);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
