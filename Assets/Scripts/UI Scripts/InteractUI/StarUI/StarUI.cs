using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
public class StarUI : MonoBehaviour
{
   [SerializeField] private Slider slider;
    private StarLight starLight;

    private void Awake()
    {
        starLight = GetComponent<StarLight>();
        slider.maxValue = 3;
        slider.minValue = 0;
    }

    void UpdateSlider()
    {
        slider.value = starLight.Intensity;
    }

    private void Update()
    {
        UpdateSlider();
    }

 
    
}
