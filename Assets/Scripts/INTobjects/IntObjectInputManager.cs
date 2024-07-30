using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public  class IntObjectInputManager : MonoBehaviour
{
    protected IntObjectControls INTObjectControls;
    
     [Header("Inputlar")]
    public Vector2 cameraMovementInput; 
    public float cameraHorizontalInput;
    public float camVerticalInput;
    public bool objectR1Input;
    public bool revertToSlimeInput;
    
     [Header("Actionlar")]
    public Action R1Action;
    public Action RevertAction;

    protected virtual void OnEnable()
    {
        if (INTObjectControls == null)
        {
            INTObjectControls = new IntObjectControls();
            INTObjectControls.Movement.Camera.performed += i => cameraMovementInput = i.ReadValue<Vector2>();
            INTObjectControls.ObjectActions.R1.performed += i => objectR1Input = true;
            INTObjectControls.ObjectActions.RevertToSlime.performed += i => revertToSlimeInput = true;
        }
        INTObjectControls.Enable();
    }

    protected void OnDisable()
    {
        INTObjectControls.Disable();
    }
   public virtual void HandleAllInput()
    {
        HandleMovementInput();
        HandleR1Input();
        HandleRevertInput();
    }
   protected virtual void  HandleMovementInput()
    {
        cameraHorizontalInput = cameraMovementInput.x;
        camVerticalInput = cameraMovementInput.y;
    }
    // ReSharper disable Unity.PerformanceAnalysis
    void HandleR1Input()
    {
        if (!objectR1Input) return;
        objectR1Input = false;
        R1Action?.Invoke();
    }
    void HandleRevertInput()
    {
        if(!revertToSlimeInput) return;
        revertToSlimeInput = false;
        RevertAction?.Invoke();
    }
}
