using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBase : MonoBehaviour {

    Animator anim;
    public bool useRootMotion = false;
    public Vector3 desiredMovement;
    public bool isRunning;
    public float speed = 2f;
    public float runSpeed = 5f;
    public float rotationSpeedMult = 5f;
    public float jumpUpForce = 10f;
    public float jumpForwardForce = 1f;
    public bool jump = false;
    Vector3 desiredMovementFlat;
    float angleToMovement;
    float leftOrRight;
    float finalSpeed;
    float groundCheckTimer = 0f;
    bool onGround = true;
    Rigidbody rb;
    AudioSource audioSource;

    Dictionary<string, float> audioTimers = new Dictionary<string, float>();
    public AudioClip[] footsteps;

    float inAir = 0f;
    RaycastHit hit;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        anim.applyRootMotion = useRootMotion;
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }

    public void Audio(string audioType)
    {

        if (!audioTimers.ContainsKey(audioType))
        {
            audioTimers.Add(audioType, Time.time);
        }

        if (Time.time >= audioTimers[audioType] + 0.25f)
        {
            audioTimers[audioType] = Time.time;
        }
        else
        {
            return;
        }

        if (audioType.Equals("Step"))
        {

            if (audioSource != null)
            {
                if (footsteps.Length > 0)
                {
                    audioSource.PlayOneShot(footsteps[Random.Range(0, footsteps.Length)]);

                }
            }
        }
    }


    void GroundCheck()
    {

        if (Physics.Raycast(transform.position + Vector3.up * 0.25f, Vector3.down, out hit, 2.25f))
        {
            inAir = Vector3.Distance(hit.point, transform.position);
        }
        else
        {
            inAir = 2f;
        }
        anim.SetFloat("InAir", inAir, 0.2f, Time.deltaTime);
        groundCheckTimer += Time.deltaTime;
        if (groundCheckTimer < 0.25f)
        {
            onGround = false;
        }
        else
        {
            if (Physics.Raycast(transform.position + Vector3.up * 0.25f, Vector3.down, 0.5f))
            {
                anim.applyRootMotion = useRootMotion;
                onGround = true;
            }
            else
            {
                onGround = false;
            }
        }
        anim.SetBool("OnGround", onGround);

    }


    void Movement()
    {

        desiredMovementFlat = desiredMovement;
        desiredMovementFlat.y = 0f;
        if (desiredMovementFlat.magnitude > 0.1f)
        {
            angleToMovement = Vector3.Angle(transform.forward, desiredMovementFlat);
        }
        else
        {
            angleToMovement = 0f;
        }
        leftOrRight = Mathf.Sign(Vector3.Dot(transform.right,desiredMovementFlat));

        angleToMovement = angleToMovement * leftOrRight;

        if (isRunning)
        {
            desiredMovementFlat = desiredMovementFlat * runSpeed;
            finalSpeed = Mathf.Clamp(desiredMovementFlat.magnitude, 0f, runSpeed);
        }
        else
        {
            desiredMovementFlat = desiredMovementFlat * speed;
            finalSpeed = Mathf.Clamp(desiredMovementFlat.magnitude, 0f, speed);
        }
        anim.SetFloat("Speed", finalSpeed, 0.25f, Time.deltaTime);
        anim.SetFloat("Angle", angleToMovement, 0.25f, Time.deltaTime);

        if (jump && onGround)
        {

            anim.applyRootMotion = false;
            groundCheckTimer = 0f;
            anim.SetTrigger("Jump");
            jump = false;
            rb.AddForce(Vector3.up * jumpUpForce + transform.forward*jumpForwardForce, ForceMode.Impulse);
        }

        if (!useRootMotion)
        {
            SimpleMovement();
        }

    }

    //private void OnAnimatorMove()
    //{
        
    //}

    void SimpleMovement()
    {
        transform.Rotate(Vector3.up, rotationSpeedMult * angleToMovement * Time.deltaTime, Space.World);
        transform.Translate(transform.forward * finalSpeed * Time.deltaTime, Space.World);
    }


	
	// Update is called once per frame
	void Update () {
        Movement();
        GroundCheck();

    }
}
