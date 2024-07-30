using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLight : MonoBehaviour
{
  private IntObjectInputManager ıntObjectInputManager;
  [SerializeField] private GameObject lampLight;
  private bool isLampOn = false;
  [SerializeField] private Transform LambTransform;
  
  private void Awake()
  {
    ıntObjectInputManager = GetComponent<IntObjectInputManager>();
  }

  private void OnEnable()
  {
    ıntObjectInputManager.R1Action += ToggleLamp;
  }

  private void OnDisable()
  {
    ıntObjectInputManager.R1Action -= ToggleLamp;
    lampLight.SetActive(false);
  }

  private void ToggleLamp()
  {
    isLampOn = !isLampOn;
    lampLight.SetActive(isLampOn);
    
  }

  private void Update()
  {
    if (isLampOn)
    {
      LampRay();
    }
  }

  private void LampRay()
  {
    float maxDistance = 8f;
    RaycastHit hit;
    Debug.DrawRay(LambTransform.position, LambTransform.forward * maxDistance, Color.red);
    if (Physics.Raycast(LambTransform.position,LambTransform.forward ,out hit,maxDistance))
    {
      if (hit.collider.TryGetComponent(out StarLight starlightObject))
      {
        var increment = 0.1f; 
        starlightObject.Intensity += increment * Time.deltaTime;
      }
    }
    
  }
  
}
