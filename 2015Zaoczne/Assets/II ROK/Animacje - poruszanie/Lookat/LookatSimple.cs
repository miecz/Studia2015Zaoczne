using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatSimple : MonoBehaviour {

    Animator anim;

    public Transform lookAtTarget;
    [Range(0f, 1f)]
    public float lookAtWeight = 0f;

    private void OnAnimatorIK(int layerIndex)
    {
        anim.SetLookAtPosition(lookAtTarget.position);
        anim.SetLookAtWeight(lookAtWeight);
    }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
