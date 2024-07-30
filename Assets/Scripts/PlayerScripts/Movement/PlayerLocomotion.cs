using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerLocomotion : MonoBehaviour
{
    private InputManager inputManager;
    private PlayerManager playerManager;
    private AnimatorManager animatorManager;
    private PlayerInteract playerInteract;
    private Vector3 moveDirection;
    [SerializeField] private Transform cameraObject;
    private Rigidbody playerRigidbody;

    [Header("Düsme")] 
    public Transform groundCheck;
    public float inAirTimer;
    public float fallingVelocity=33;
    public float leapingVelocity=2;
    public LayerMask groundLayer;
    public float maxDistance = 1;
    [Header("Boollar")]
    public bool isSprinting;
    public bool isGrounded;
    public bool isJumping;
    
    [Header("Hareket")]
    public float walkingSpeed = 1.5f;
    public float runningSpeed=5f; 
    public float sprintingSpeed = 7f;
    public float RotationSpeed = 15f;
    public float climbingSpeed=5;

    [Header("Zıplama")] 
    public float  jumpHeight= 1;

    public float gravityInstensity = -20f;

    public bool isClimbing;

    public Vector3 boxSize;
    private void Awake()
    {
        animatorManager=GetComponent<AnimatorManager>();
        playerManager = GetComponent<PlayerManager>();
        inputManager = GetComponent<InputManager>();
        playerInteract = GetComponent<PlayerInteract>();
        playerRigidbody = GetComponent<Rigidbody>();
        if (Camera.main != null) cameraObject = Camera.main.transform;
    }

    public void HandleAllMovement()
    {
        
        HandleFallingAndLanding();
        if(playerManager.isInteracting)
            return;
        HandleMovement();
        HandleRotation();
    }
    private void HandleMovement()
    {
       if(isJumping) return;
        moveDirection = cameraObject.forward * inputManager.VerticalInput;
        moveDirection = moveDirection + cameraObject.right * inputManager.HorizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        if (isSprinting)
        {
            moveDirection = moveDirection.normalized * sprintingSpeed;
        }
        else
        {
            if (inputManager.moveAmount >= 0.5f)
            {
                moveDirection = moveDirection.normalized * runningSpeed;
            }
            else
            {
                moveDirection = moveDirection.normalized * walkingSpeed;
            }
            
        }
        Vector3 movementVelocity = moveDirection;
        playerRigidbody.velocity = movementVelocity;

    }

    /*public void HandleClimb()
    {
        if (inputManager.moveAmount == 0 && playerInteract.hit.collider!=null)
        {
            var player = gameObject;
            moveDirection = player.transform.right * inputManager.ClimbHorizontalInput;
            moveDirection = moveDirection+player.transform.up*inputManager.ClimbVerticalInput;
            moveDirection.z = 0f;
            moveDirection.Normalize();
            Vector3 climbVelocity = moveDirection * climbingSpeed;
            playerRigidbody.velocity = climbVelocity;
            isGrounded = true;
            isJumping = false;
        }
        else
        {
            isClimbing = false;
        }
    }*/
    private void HandleRotation()
    {
      //  if(isJumping) return;
        Vector3 targetDirection = Vector3.zero;

        targetDirection = cameraObject.forward * inputManager.VerticalInput;
        targetDirection = targetDirection + cameraObject.right * inputManager.HorizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation,targetRotation,RotationSpeed*Time.deltaTime);

        transform.rotation = playerRotation;
    }

    private void HandleFallingAndLanding()
    {
        if (!isGrounded && !isJumping)
        {
            if (!playerManager.isInteracting)
            {
                animatorManager.PlayTargetAnimation("Falling",true);
                
            }
            inAirTimer = inAirTimer+ Time.deltaTime;
            playerRigidbody.AddForce(transform.forward*leapingVelocity); 
            playerRigidbody.AddForce(-Vector3.up * (fallingVelocity * inAirTimer));
            
        }

        if (ChechBoxGroundCheck())
        {
          
            if (!isGrounded && !playerManager.isInteracting)
            {
                animatorManager.PlayTargetAnimation("Land",true);
                
            }
            inAirTimer = 0;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
            
        }
        
    }

    bool ChechBoxGroundCheck()
    {
        if (Physics.CheckBox(groundCheck.position, boxSize, groundCheck.rotation, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(groundCheck.position,boxSize);
    }

    public void HandleJump()
    {
        if (!isGrounded) return;
        animatorManager.animator.SetBool("isJumping",true);
        animatorManager.PlayTargetAnimation("Jump",false);
        
        float jumpingVelocity = Mathf.Sqrt(-2 * gravityInstensity * jumpHeight);
        playerRigidbody.AddForce(Vector3.up * jumpingVelocity, ForceMode.VelocityChange);
        
         /*Vector3 playerVelocity = moveDirection;
         playerVelocity.y = jumpingVelocity;
         playerRigidbody.velocity = playerVelocity;*/

    }
 
}
