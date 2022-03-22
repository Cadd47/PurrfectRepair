using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerOneMovement : MonoBehaviour
{

    [SerializeField] ParticleSystem sprintParticle = null;
    [SerializeField] ParticleSystem jumpParticle = null;
    public GameObject sprintCheck;

    public CharacterController controller;
    public Transform cam;

    public float speed = 8;
    public float gravity = -27.5f;
    
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


    void Start()
    {
        sprintParticle.Stop();
    }

    void Jump()
    {
        jumpParticle.Play();
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

        if (Input.GetKeyDown(KeyCode.Space) && velocity.y < 0 && isGrounded)
        {
            isJumping = true;
            jumpTimeCounter = 0.25f;
            Jump();

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

        //sprint
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 14;
            sprintCheck.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 8;
            sprintCheck.SetActive(true);
            jumpParticle.Stop();
        }

        //sprint particle check
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            sprintParticle.Play();
        }
        else
        {
            sprintParticle.Stop();
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