using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarLight : MonoBehaviour
{
   [SerializeField] private Light light;
   private float _intensity;

   public float Intensity
   {
      get => _intensity;
      set
      {
         _intensity = value;
         UpdateLightIntensity();
      }
   }
   private void UpdateLightIntensity()
   {
      if (light != null)
      {
         light.intensity = _intensity;
      }
   }
   
}
