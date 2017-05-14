using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerWeight : MonoBehaviour {
    Animator anim;
    [Range(0f,1f)]
    public float animWeight;

    float targetWeight;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
    

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            targetWeight = 1f;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            targetWeight = 0f;
        }
        animWeight = Mathf.Lerp(animWeight, targetWeight, Time.deltaTime*2f);
        anim.SetLayerWeight(1, animWeight);
		
	}
}
