using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonManager : MonoBehaviour
{
   private CannonLocomotion _cannonLocomotion;
   private IntObjectInputManager _ıntObjectInputManager;


   
   private void Awake()
   {
      _cannonLocomotion = GetComponent<CannonLocomotion>();
      _ıntObjectInputManager = GetComponent<IntObjectInputManager>();
   }

   private void Update()
   {
     _ıntObjectInputManager.HandleAllInput();
   }

   private void LateUpdate()
   {
      _cannonLocomotion.HandleAllCameraMovement();
   }
}
