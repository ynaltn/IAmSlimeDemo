using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CannonLocomotion : MonoBehaviour
{
    private IntObjectInputManager ıntObjectInputManager;
    private float xRotation;
    private float yRotation;
    [SerializeField] private float rotationSpeed=1;
    [SerializeField] [Range(-360,360)] private float minXangle;
    [SerializeField] [Range(-360,360)] private float maxXangle;
    [SerializeField] private Transform cameraFollowTarget;
    [SerializeField] [Range(-360, 360)] private float minYangle;
    [SerializeField] [Range(-360, 360)] private float maxYangle;
    private void Awake()
    {
        ıntObjectInputManager = GetComponent<IntObjectInputManager>();
        
    }

    private void OnEnable()
    {
        ResetRotation();
    }

    private void OnDisable()
    {
       ResetRotation();
    }
    private void ResetRotation()
    {
        xRotation = 0f;
        yRotation = 0f;
    }
    public void HandleAllCameraMovement()
    {
        HandleRotation();
    }
   
     private void HandleRotation()
     {
         xRotation += (ıntObjectInputManager.cameraHorizontalInput*rotationSpeed*Time.deltaTime);
         xRotation = Mathf.Clamp(xRotation, minXangle, maxXangle);
         yRotation += (ıntObjectInputManager.camVerticalInput * rotationSpeed*Time.deltaTime);
         yRotation = Mathf.Clamp(yRotation, minYangle, maxYangle);
         Quaternion currentRotation = cameraFollowTarget.localRotation;
         Quaternion rotation = Quaternion.Euler(yRotation,xRotation,currentRotation.eulerAngles.z);
         cameraFollowTarget.localRotation = rotation;
     }
     
}
