 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InputManager : MonoBehaviour
{
    private PlayerControls playerControls;
    private PlayerLocomotion playerLocomotion;
    private PlayerManager playerManager;
    
    [Header("Animasyon")]
    private AnimatorManager animatorManager;
    public float moveAmount;
    
    [Header("Oyuncu ve Hareketi")]
    public Vector2 MovementInput;
    public float HorizontalInput;
    public float VerticalInput;
    
    
    [Header("Kamera ve Hareketi")]
    public Vector2 cameraMovementInput;
    public float cameraHorizontalInput;
    public float cameraVerticalInput;

    [Header("Tırmanma")]
    public Vector2 ClimbMovementInput;
    public float ClimbHorizontalInput;
    public float ClimbVerticalInput;
    
    [Header("Inputlar")]
    public bool sprintingInput;
    public bool jumpInput;
    public bool divideInput;
    public bool uniteInput;
    public bool teleportInput;
    public bool interactInput;
    
    
    public Action ActionDivide;
    public Action ActionUnite;
    public Action ActionTeleport;
    public Action ActionInteract;
    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        playerManager = GetComponent<PlayerManager>();

    }

    private void OnEnable()
    {
       
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
            playerControls.PlayerMovement.Movement.performed += i => MovementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraMovementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.ClimbMovement.performed += i => ClimbMovementInput = i.ReadValue<Vector2>();
            
            playerControls.PlayerActions.Sprint.performed += i => sprintingInput = true;
            playerControls.PlayerActions.Sprint.canceled += i => sprintingInput = false;
            playerControls.PlayerActions.Jump.performed += i => jumpInput = true;
            playerControls.PlayerActions.Divide.performed += i => divideInput = true;
            playerControls.PlayerActions.Unite.performed += i => uniteInput = true;
            
            playerControls.PlayerActions.Teleport.performed += i => teleportInput = true;
            playerControls.PlayerActions.Interact.performed += i => interactInput = true;
        }
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInput()
    {
        
       HandleJumpingInput();
       HandleDivideInput();
       HandleUniteInput();
       HandleTeleportInput();
       HandleInteract();
       HandleClimbMovement();
       HandleMovementInput();
       HandleSprintingInput();
    }

    private void HandleMovementInput()
    {
        //KarakterHareket
        VerticalInput = MovementInput.y;
        HorizontalInput = MovementInput.x;
        //Animasyon
        moveAmount = Mathf.Clamp01(Mathf.Abs(HorizontalInput) + Mathf.Abs(VerticalInput));
        animatorManager.UptadeAnımatorValues(0,moveAmount,playerLocomotion.isSprinting);
        //KameraHareket
        cameraVerticalInput = cameraMovementInput.y;
        cameraHorizontalInput = cameraMovementInput.x;
    }

    private void HandleClimbMovement()
    {
        
        ClimbVerticalInput = ClimbMovementInput.y;
        ClimbHorizontalInput = ClimbMovementInput.x;
        
    }
    private void HandleSprintingInput()
    {
        
        if (sprintingInput && moveAmount>0.5f)
        {
            playerLocomotion.isSprinting = true;
        }
        else
        {
            playerLocomotion.isSprinting = false;
        }
    }

    private void HandleJumpingInput()
    {
        if (!jumpInput) return;
        jumpInput = false;
        playerLocomotion.HandleJump();
    }
    private void HandleDivideInput()
    {
        if (!divideInput) return;
        
        divideInput = false;
        ActionDivide?.Invoke();

    }

    private void HandleUniteInput()
    {
        if (!uniteInput) return;
        uniteInput = false;
        ActionUnite?.Invoke();
    }

    private void HandleTeleportInput()
    {
        if(!teleportInput || playerManager.isInteracting) return;
        ActionTeleport?.Invoke();
        teleportInput = false;
    }
    
    private void HandleInteract()
    { 
        if(!interactInput) return;
        ActionInteract?.Invoke();
        interactInput = false;
    }
}
