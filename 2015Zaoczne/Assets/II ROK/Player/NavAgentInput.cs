using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentInput : MonoBehaviour {

    public float doubleClickTime = 0.3f;
    bool firstClick = false;
    bool doubleClick = false;
    float timer;
    NavMeshAgent agent;
    MovementBase movement;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        movement = GetComponent<MovementBase>();
	}


    RaycastHit hit;

    void CheckDoubleClick()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (firstClick)
            {
                doubleClick = true;
            }
            else
            {
                firstClick = true;
                doubleClick = false;
                timer = 0f;
            }
            
        }
        if (firstClick)
        {
            timer += Time.deltaTime;
            if (timer >= doubleClickTime)
            {
                firstClick = false;
            }
        }
    }

	// Update is called once per frame
	void Update () {

        CheckDoubleClick();
        if (Input.GetButtonDown("Fire1"))
        {
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
        movement.isRunning = doubleClick;

        agent.updateRotation = false;
        agent.updatePosition = false;
        movement.desiredMovement = agent.desiredVelocity;
        agent.nextPosition = transform.position;
	}
}
