using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class StarInputManager : IntObjectInputManager
{
    [SerializeField] private Vector2 movementInput;
     public float horizontalInput;
     public float verticalInput;
    protected override void OnEnable()
    {
        base.OnEnable();
        INTObjectControls.Movement.INTMovement.performed += i => movementInput = i.ReadValue<Vector2>();
      
    }
    public override void HandleAllInput()
    {
        base.HandleAllInput();
        HandleMovementInput();
    }
    protected override void HandleMovementInput()
    {
        base.HandleMovementInput();
        horizontalInput = movementInput.x;
        verticalInput = movementInput.y;
    }
}
