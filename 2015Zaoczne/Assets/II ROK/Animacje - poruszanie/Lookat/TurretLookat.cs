using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLookat : MonoBehaviour {

    public Transform rotor;
    public Transform gun;
    public Transform target;

    public float rotationSpeed = 0.1f;

    Vector3 toTargetRaw;
    Vector3 toTarget;

    Vector3 gunRot;
    Vector3 rotorRot;

    private void Start()
    {
        toTarget = gun.forward;
    }

    void LookAt()
    {
        toTargetRaw = target.position - gun.position;
        toTarget = Vector3.Slerp(toTarget, toTargetRaw, Time.deltaTime * rotationSpeed);

        rotorRot = toTarget;
        rotorRot.y = 0f;
        gunRot = toTarget;

        rotor.rotation = Quaternion.LookRotation(rotorRot);
        gun.rotation = Quaternion.LookRotation(gunRot);

    }
	
	// Update is called once per frame
	void Update () {
        LookAt();
	}
}
