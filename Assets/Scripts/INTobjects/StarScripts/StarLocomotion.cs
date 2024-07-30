using System;
using System.Collections;
using UnityEngine;

public class StarLocomotion : MonoBehaviour
{
   private Rigidbody _rb;
   private StarInputManager _starInputManager;
   private Vector3 _moveDirection;
   [SerializeField] private float walkingSpeed;
   [SerializeField] private float rotationSpeed;
   [SerializeField] private Transform groundCheck;
   [SerializeField] private Vector3 boxSize;
   [SerializeField] private bool isGrounded;
   [SerializeField] private float inAirTimer;
   [SerializeField] private float fallingVelocity;
   [SerializeField] private float leapingVelocity;
   [SerializeField] private LayerMask groundLayer;

  [SerializeField] private Transform cameraObject;

   private void Awake()
   {
      _rb = GetComponent<Rigidbody>();
      _starInputManager = GetComponent<StarInputManager>();
   }
   public void HandleAllMovement()
   {
      HandleMovement();
      HandleRotation();
      HandleFalling();
   }
  
   // private void HandleMovement()
   // {
   //    if(!GroundCheck()) return;
   //    _moveDirection = cameraObject.forward * _starInputManager.verticalInput;
   //    _moveDirection = _moveDirection + cameraObject.right * _starInputManager.horizontalInput;
   //    _moveDirection.Normalize();
   //    _moveDirection = _moveDirection.normalized * walkingSpeed ;
   //    Vector3 movementVelocity=_moveDirection;
   //    _rb.velocity = movementVelocity;
   // }
   //
   // private void HandleRotation()
   // {
   //    Vector3 targetDirection = Vector3.zero;
   //    targetDirection = cameraObject.forward * _starInputManager.verticalInput;
   //    targetDirection = targetDirection + cameraObject.right * -_starInputManager.horizontalInput;
   //    targetDirection.Normalize();
   //    targetDirection.y = 0;
   //    if (targetDirection == Vector3.zero)
   //    {
   //       targetDirection = transform.forward;
   //    }
   //
   //    Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
   //    Quaternion playerRotation= Quaternion.Slerp(transform.rotation,targetRotation,rotationSpeed*Time.deltaTime);
   //    transform.rotation = playerRotation;
   // }
   private void HandleMovement()
   {
      if (!GroundCheck()) return;

      Vector3 cameraForward = cameraObject.forward;
      Vector3 cameraRight = cameraObject.right;

      // İleri ve sağ vektörleri yatay düzleme yerleştir
      cameraForward.y = 0;
      cameraRight.y = 0;

      _moveDirection = cameraForward * _starInputManager.verticalInput + cameraRight * _starInputManager.horizontalInput;
      _moveDirection.Normalize();
      _moveDirection *= walkingSpeed;

      _rb.velocity = new Vector3(_moveDirection.x, _rb.velocity.y, _moveDirection.z);
   }

   private void HandleRotation()
   {
      // Karakter hareket ederken yalnızca hareket yönüne dönsün
      if (_moveDirection == Vector3.zero) return;

      Vector3 targetDirection = _moveDirection;
      targetDirection.y = 0;
      Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
      Quaternion smoothedRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
      transform.rotation = smoothedRotation;
   }

   private void HandleFalling()
   {
     
      if (GroundCheck())
      {
         inAirTimer = 0;
         isGrounded = true;
      }
      else
      {
         isGrounded = false;
      }
      
      if (!isGrounded)
      {
         inAirTimer +=Time.deltaTime;
         _rb.AddForce(transform.forward*leapingVelocity); 
         _rb.AddForce(Vector3.down* (fallingVelocity * inAirTimer));
      }
      
      
   }

   bool GroundCheck()
   {
      if (Physics.CheckBox(groundCheck.position, boxSize, groundCheck.rotation,groundLayer))
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
}
