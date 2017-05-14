using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatManual : MonoBehaviour {

    public Transform lookAtTarget;
    public Transform lookBone;
    public Vector3 correctiveRotation;
    public float maxLookAngle = 70f;
    public float lookDamp = 0.5f;

    Vector3 lookAtVector;
    Vector3 lookVelocity;
    Vector3 lookAtVectorRaw;

	// Use this for initialization
	void Start () {
        lookAtVector = transform.forward;
	}

    void LookAt()
    {
        if (lookAtTarget != null && lookAtTarget.gameObject.activeInHierarchy)
        {
            lookAtVectorRaw = lookAtTarget.position - lookBone.position;

            if (Vector3.Angle(lookAtVectorRaw, transform.forward) > maxLookAngle)
            {
                lookAtVectorRaw = Vector3.RotateTowards(transform.forward, lookAtVectorRaw, Mathf.Deg2Rad*maxLookAngle, 0f);
            }

            lookAtVector = Vector3.SmoothDamp(lookAtVector, lookAtVectorRaw, ref lookVelocity, lookDamp);

            lookBone.rotation = Quaternion.LookRotation(lookAtVector);
           
            lookBone.Rotate(correctiveRotation);
        }
       
    }

    private void LateUpdate()
    {
        LookAt();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
