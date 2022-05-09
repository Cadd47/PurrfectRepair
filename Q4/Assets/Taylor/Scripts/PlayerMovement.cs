using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] ParticleSystem sprintParticle;
    [SerializeField] ParticleSystem jumpParticle;
    [SerializeField] ParticleSystem landParticle;

    public CharacterController controller;
    public Transform cam;

    public float speed = 10;
    public float gravity;
    
    public float jumpHeight;
    private float jumpTimeCounter;
    public bool isJumping;

    Vector3 velocity;
    bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.15f;

    public bool isIdle;
    public bool isWalking;
    public bool isRunning;

    IEnumerator checkLanded()
    {
        landParticle.Stop();

        while (!isGrounded)
        {
            yield return null;
        }

        landParticle.Play();

    }

    // Update is called once per frame
    void Update()
    {
        //jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //check if not grounded
        if (!isGrounded)
        {
            StartCoroutine(checkLanded());
        }

        if (Input.GetKeyDown(KeyCode.Space) && velocity.y < 0 && isGrounded)
        {
            isJumping = true;
            jumpTimeCounter = 0.25f;
            jumpParticle.Play();

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //walk
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        
        if(horizontal > 0 || vertical > 0 || horizontal < 0 || vertical < 0)
        {
            isIdle = false;
            isWalking = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
            speed = 10f;
            sprintParticle.Stop();
        }

        if (horizontal == 0 && vertical == 0)
        {
            isRunning = false;
            isWalking = false;
            isIdle = true;
            speed = 10f;
            sprintParticle.Stop();
        }

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            speed = 22.5f;

            if (horizontal == 0 && vertical == 0)
            {
                sprintParticle.Stop();
                isRunning = false;
            }
            else
            {
                isIdle = false;
                isWalking = false;
                isRunning = true;
                sprintParticle.Play();
            }
        }

        //camera
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
}