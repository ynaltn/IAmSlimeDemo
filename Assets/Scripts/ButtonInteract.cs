using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteract : MonoBehaviour
{
   [SerializeField]private GameObject Door;
   [SerializeField] private string message;

   private void OnTriggerEnter(Collider other)
   {
      Destroy(Door);
      UIStandart.instance.ShowPlayerTextWindow("",message);
   }
}
