using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public Vector3 velocity;
    [HideInInspector] public bool isSprinting;

    [Header("Components")]
    [SerializeField] private PlayerAnimation playerAnimation;
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform cam;

    [Header("Movement")]
    [SerializeField] private Transform body;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 1000f;
    [SerializeField] private float sprintSpeedMult = 2f;
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] private float gravityForce = -9.81f;
    [SerializeField] public float defaultVelocityY = -1f;
    [SerializeField] private float velocityCoolingSpeed = 0.75f;

    [Header("Environment")]
    [SerializeField] private Transform ceilingCheck;
    [SerializeField] private float ceilingCheckRadius = 0.25f;
    [SerializeField] private LayerMask ceilingMask;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.25f;
    [SerializeField] private LayerMask groundMask;

    private void Update()
    {
        ComputeVelocityXZ();
        ComputeVelocityY();
        MovePlayer();

        if (controller.velocity.x != 0f || controller.velocity.z != 0f)
        {
            RotateBody();
        }
    }

    private void ComputeVelocityXZ()
    {
        if (IsOnGround())
        {
            velocity.x = Input.GetAxis("Horizontal") * speed;
            velocity.z = Input.GetAxis("Vertical") * speed;
        }
        else
        {
            velocity.x = Mathf.Lerp(velocity.x, 0f, Time.deltaTime * velocityCoolingSpeed);
            velocity.z = Mathf.Lerp(velocity.z, 0f, Time.deltaTime * velocityCoolingSpeed);
        }

        HandleSprint();
    }

    private void HandleSprint()
    {
        if (Input.GetButton("Sprint") && IsOnGround())
        {
            velocity.x *= sprintSpeedMult;
            velocity.z *= sprintSpeedMult;
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
    }

    private void ComputeVelocityY()
    {
        if (IsOnGround() || IsUnderCeiling() && velocity.y > defaultVelocityY)
        {
            velocity.y = defaultVelocityY;
        }
        else
        {
            velocity.y += gravityForce * Time.deltaTime;
        }

        HandleJumping();
    }

    private void HandleJumping()
    {
        if (Input.GetButton("Jump") && IsOnGround())
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravityForce);
            playerAnimation.Jump();
        }
    }

    private void MovePlayer()
    {
        Vector3 direction = cam.right * velocity.x + transform.up * velocity.y + cam.forward * velocity.z;
        controller.Move(direction * Time.deltaTime);
    }

    private void RotateBody()
    {
        Quaternion lookRotation = Quaternion.LookRotation(controller.velocity, Vector3.up);
        lookRotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f);
        body.rotation = Quaternion.RotateTowards(body.rotation, lookRotation, rotationSpeed * Time.deltaTime);
    }

    private bool IsUnderCeiling()
    {
        return Physics.CheckSphere(ceilingCheck.position, ceilingCheckRadius, ceilingMask);
    }

    public bool IsOnGround()
    {
        return Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);
    }
}
