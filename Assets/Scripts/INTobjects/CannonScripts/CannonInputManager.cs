using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CannonInputManager : MonoBehaviour
{
   private CannonControls cannonControls;
   
   [Header("Inputlar")]
   public Vector2 cameraMovementInput;
   public float cameraHorizontalInput;
   public float cannonAimVerticalInput;
   public bool cannonShootInput;
   public bool revertToSlimeInput;
   
   [Header("Actionlar")]
   public Action ShootAction;
   public Action RevertAction;
   private void OnEnable()
   {
      if (cannonControls == null)
      {
         cannonControls = new CannonControls();
         cannonControls.Movement.Camera.performed += i => cameraMovementInput = i.ReadValue<Vector2>();
         cannonControls.CannonActions.Shoot.performed += i => cannonShootInput = true;
         cannonControls.CannonActions.RevertToSlime.performed += i => revertToSlimeInput = true;
         
      }
      cannonControls.Enable();
   }
   private void OnDisable()
   {
      cannonControls.Disable();
   }
   
   public void HandleAllInput()
   {
      HandleCameraInput();
      HandleShoot();
      HandleRevert();
   }
   void HandleCameraInput()
   {
      cameraHorizontalInput = cameraMovementInput.x;
      cannonAimVerticalInput = cameraMovementInput.y;
   }
   void HandleShoot()
   {
      if (!cannonShootInput) return;
      cannonShootInput = false;
      ShootAction?.Invoke();
   }
   void HandleRevert()
   {
      if(!revertToSlimeInput) return;
      revertToSlimeInput = false;
      RevertAction?.Invoke();
   }
}
