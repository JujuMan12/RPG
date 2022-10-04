using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public Vector3 velocity;
    [HideInInspector] public bool isRunning;
    [HideInInspector] private bool isCrouching;

    [Header("Movement")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float sprintSpeedMult = 2f;
    [SerializeField] private float crouchSpeedMult = 0.5f;
    [SerializeField] private float crouchScaleYMult = 0.5f;
    [SerializeField] private float crouchTransitionSpeed = 1f;
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
        HandleMovement();
        HandleFalling();
        HandleVelocity();

        if (IsOnGround())
        {
            if (Input.GetButtonDown("Crouch"))
            {
                isCrouching = !isCrouching;
            }
        }
    }

    //private void FixedUpdate()
    //{
    //    HandleCrouching();
    //}

    private void HandleMovement()
    {
        if (IsOnGround())
        {
            velocity.x = Input.GetAxis("Horizontal") * speed;
            velocity.z = Input.GetAxis("Vertical") * speed;

            if (Input.GetButton("Sprint"))
            {
                velocity.x *= sprintSpeedMult;
                velocity.z *= sprintSpeedMult;
                isCrouching = false;
            }
            else if (isCrouching)
            {
                velocity.x *= crouchSpeedMult;
                velocity.z *= crouchSpeedMult;
            }
        }
        else
        {
            velocity.x = Mathf.Lerp(velocity.x, 0f, Time.deltaTime * velocityCoolingSpeed);
            velocity.z = Mathf.Lerp(velocity.z, 0f, Time.deltaTime * velocityCoolingSpeed);
        }
    }

    private void HandleFalling()
    {
        if (IsOnGround() || IsUnderCeiling() && velocity.y > defaultVelocityY)
        {
            velocity.y = defaultVelocityY;
        }
        else
        {
            velocity.y += gravityForce * Time.deltaTime;
            if (isCrouching && (velocity.y < defaultVelocityY - 1f || velocity.y > defaultVelocityY + 1f))
            {
                isCrouching = false;
            }
        }

        if (IsOnGround() && Input.GetButton("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravityForce);
        }
    }

    private void HandleVelocity()
    {
        Vector3 direction = transform.right * velocity.x + transform.up * velocity.y + transform.forward * velocity.z;
        characterController.Move(direction * Time.deltaTime);
    }

    //private void HandleCrouching()
    //{
    //    float newScaleY = transform.localScale.y;
    //    float targetScaleY = defaultScaleY;
    //    float newPositionY = transform.position.y;
    //    float targetPositionY = newPositionY + 0.5f * crouchScaleYMult;

    //    if (isCrouching)
    //    {
    //        targetScaleY *= crouchScaleYMult;
    //        targetPositionY = newPositionY - 2f * crouchScaleYMult;
    //    }

    //    if (newScaleY < targetScaleY - 0.05f || newScaleY > targetScaleY + 0.05f)
    //    {
    //        newScaleY = Mathf.Lerp(newScaleY, targetScaleY, Time.deltaTime * crouchTransitionSpeed);
    //        newPositionY = Mathf.Lerp(newPositionY, targetPositionY, Time.deltaTime * crouchTransitionSpeed);
    //        transform.localScale = new Vector3(transform.localScale.x, newScaleY, transform.localScale.z);
    //        transform.position = new Vector3(transform.position.x, newPositionY, transform.position.z);
    //    }
    //    else
    //    {
    //        transform.localScale = new Vector3(transform.localScale.x, targetScaleY, transform.localScale.z);
    //    }
    //}

    private bool IsUnderCeiling()
    {
        return Physics.CheckSphere(ceilingCheck.position, ceilingCheckRadius, ceilingMask);
    }

    private bool IsOnGround()
    {
        return Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);
    }
}
