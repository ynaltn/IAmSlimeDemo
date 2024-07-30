using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLocomotion : MonoBehaviour
{
    private IntObjectInputManager _ıntObjectInputManager;
    [SerializeField] private GameObject LampHead; // x değiştir
    [SerializeField] private GameObject LampBody; // y değiştir
    private float _lampHeadRotation;
    private float _lampBodyRotation;

    [SerializeField] private float rotationSpeed;

    [SerializeField] [Range(-360, 360)] private float minHeadangle;
    [SerializeField] [Range(-360, 360)] private float maxHeadangle;
    [SerializeField] [Range(-360, 360)] private float minBodyangle;
    [SerializeField] [Range(-360, 360)] private float maxBodyangle;

    private void Awake()
    {
        _ıntObjectInputManager = GetComponent<IntObjectInputManager>();
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
        _lampHeadRotation = 0f;
        _lampBodyRotation = 0f;
    }

    public void HandleAllMovement()
    {
        HandleBodyRotation();
        HandleHeadRotation();
    }

    private void HandleHeadRotation()
    {
        _lampHeadRotation += (_ıntObjectInputManager.camVerticalInput * rotationSpeed * Time.deltaTime);
        _lampHeadRotation = Mathf.Clamp(_lampHeadRotation, minHeadangle, maxHeadangle);

        Quaternion currentRotation = LampHead.transform.localRotation;
        Quaternion newRotation = Quaternion.Euler(_lampHeadRotation, currentRotation.eulerAngles.y, currentRotation.eulerAngles.z);
        LampHead.transform.localRotation = newRotation;
    }

    private void HandleBodyRotation()
    {
        _lampBodyRotation += (_ıntObjectInputManager.cameraHorizontalInput * rotationSpeed * Time.deltaTime);
        _lampBodyRotation = Mathf.Clamp(_lampBodyRotation, minBodyangle, maxBodyangle);

        Quaternion currentRotation = LampBody.transform.localRotation;
        Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x, _lampBodyRotation, currentRotation.eulerAngles.z);
        LampBody.transform.localRotation = newRotation;
    }
    
}
