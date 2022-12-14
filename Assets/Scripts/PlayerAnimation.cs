using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [HideInInspector] private enum AnimationStates { idle, falling, moving, running };

    [Header("Components")]
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private CharacterController controller;

    [Header("Animation")]
    [SerializeField] private Animator animator;
    [SerializeField] private float movingThreshold = 0.5f;

    private void FixedUpdate()
    {
        UpdateAnimState();
    }

    private void UpdateAnimState()
    {
        if (playerMovement.IsOnGround())
        {
            float speedX = Mathf.Abs(controller.velocity.x);
            float speedZ = Mathf.Abs(controller.velocity.z);

            if (speedX >= movingThreshold || speedZ >= movingThreshold)
            {
                if (playerMovement.isSprinting)
                {
                    animator.SetInteger("state", (int)AnimationStates.running);
                }
                else
                {
                    animator.SetInteger("state", (int)AnimationStates.moving);
                }
            }
            else
            {
                animator.SetInteger("state", (int)AnimationStates.idle);
            }
        }
        else if (controller.velocity.y < 0f) //if (animator.GetInteger("state") != (int)AnimationStates.falling) //TODO
        {
            animator.SetInteger("state", (int)AnimationStates.falling);
        }
    }

    public void Jump()
    {
        animator.SetTrigger("jump");
    }
}
