using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LampManager : MonoBehaviour
{
    private LampLocomotion _lampLocomotion;
    private IntObjectInputManager _ıntObjectManager;
    private void Awake()
    {
        _lampLocomotion = GetComponent<LampLocomotion>();
        _ıntObjectManager = GetComponent<IntObjectInputManager>();
    }

    private void Update()
    {
        _ıntObjectManager.HandleAllInput();
    }

    private void LateUpdate()
    {
        _lampLocomotion.HandleAllMovement();
    }
}
