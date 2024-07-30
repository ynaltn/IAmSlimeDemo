using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header("Surukle")]
    public InputManager inputManager;
    public Transform TargetTransform;// takip edecegi
    public Transform cameraPivot;// yukarı asagı
    public Transform cameraTransform;// sahnedeki kamera
    
    [Header("Kamera takip")]
    public float cameraFollowSpeed=0.4f;
    private Vector3 cameraFollowVelocity=Vector3.zero;
    
    [Header("Carpisma")]
    public LayerMask collisionLayers;// carpismasini istediklerimiz
    private Vector3 cameraVectorPosition;
    public float minimumCollisionOffset=0.2f;
    public float cameraCollisionOffset = 0.2f;
    public float cameraCollisionRadius = 0.2f;
    private float defaultPosition;
    
    [Header("Donme")]
    public float cameraXSpeed = 1f;
    public float cameraYSpeed = 1f;
    public float maxYangle = 50f;
    public float minYangle = -15f;
    private float cameraX;  // inputlarla esitle
    private float cameraY; // **

    private void Awake()
    {
        if (Camera.main != null) cameraTransform = Camera.main.transform;
        defaultPosition = cameraTransform.position.z;
    }

   /* private void OnEnable()
    {
        cameraPivot.localRotation=quaternion.identity;
        
    }*/

    public void HandleAllCameraMovement()
    {
        
        FollowTarget();
        HandleCameraCollision();
        if(GameManager.instance.isInDialogue) return;
        RotateCamera();
    }
    private void FollowTarget()
   {
       Vector3 TargetPosition = Vector3.SmoothDamp(transform.position, TargetTransform.position,
           ref cameraFollowVelocity, cameraFollowSpeed);
       transform.position = TargetPosition;
   }

    private void RotateCamera()
    {
        Vector3 rotation;
        Quaternion targetRotation;
        // pivot sag sol look yukarı asa
        cameraY = cameraY - (inputManager.cameraVerticalInput * cameraXSpeed);
        cameraX = cameraX + (inputManager.cameraHorizontalInput * cameraYSpeed);
        cameraY = Mathf.Clamp(cameraY, minYangle, maxYangle);
        
        rotation = Vector3.zero;
        rotation.y = cameraX; 
        targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;
        
        rotation=Vector3.zero;
        rotation.x = cameraY;
        targetRotation= Quaternion.Euler(rotation);
        cameraPivot.localRotation = targetRotation;


    }

    private void HandleCameraCollision()
    {
        float targetPosition = defaultPosition;
        RaycastHit hit;
        Vector3 direction = cameraTransform.position - cameraPivot.position;
        direction.Normalize();
        if (Physics.SphereCast(cameraPivot.transform.position, cameraCollisionRadius, direction, out hit,
                Math.Abs(targetPosition),collisionLayers))
        {
            float distance = Vector3.Distance(cameraPivot.position, hit.point);
            targetPosition =- (distance - cameraCollisionOffset);
        }

        if (Mathf.Abs(targetPosition) < minimumCollisionOffset)
        {
            targetPosition -= minimumCollisionOffset;
        }

        cameraVectorPosition.z = Mathf.Lerp(cameraTransform.localPosition.z, targetPosition, 0.2f);
        cameraTransform.localPosition = cameraVectorPosition;


    }

   /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawSphere(cameraPivot.transform.position,cameraCollisionRadius);
    }*/
}
