using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampButtonInteract : MonoBehaviour,IInteractable
{
   [SerializeField] private GameObject roomLamp;
   [SerializeField] private bool isLampOpen = false;
   public static Action LampButtonAction;
   
   public void interact()
   {
       if(isLampOpen) return;
      ToggleLamp();
   }
   private void ToggleLamp()
   {
       isLampOpen = true;
       SoundEffectManager.Instance.SoundEffect(SoundEffectManager.Instance.lampOnOffClip,true);
       roomLamp.SetActive(false);
       LampButtonAction?.Invoke();
   }
}
