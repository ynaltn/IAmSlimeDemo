using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoTextTrigger : MonoBehaviour
{
   [SerializeField] private string Message;
   private void OnTriggerEnter(Collider col)
   {
      if (col.gameObject.CompareTag("Player"))
      {
         GameManager.instance.isInDialogue = true;
         UIStandart.instance.ShowInfoWindow("Bilgi",Message, () =>
         {
            Destroy(gameObject);
             GameManager.instance.isInDialogue = false;
         } );
        
      }
   }

   private void OnTriggerExit(Collider col)
   {
      if (col.gameObject.CompareTag("Player"))
      {
         GameManager.instance.isInDialogue = false;
      }
      
   }
}
