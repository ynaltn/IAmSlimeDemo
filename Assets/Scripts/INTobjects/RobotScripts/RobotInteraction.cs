using System;
using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class RobotInteraction : MonoBehaviour,IInteractable
{
    [SerializeField] private NPCConversation _npcFirstConversation;
    [SerializeField] private NPCConversation _npcSecondConversation;

    [SerializeField] private bool isFirstComplete;
    [SerializeField] private bool isStar;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject holeWall;

    public static Action FirstConversationAction;
    private BoxCollider _boxCollider;
    [Header("Cams")]
    public GameObject StarCam;
    public GameObject playerCam;
    public GameObject InteractionCam;

    private void Awake()
    {
       _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider col)
   {
      if (col.gameObject.CompareTag("Player"))
      {
         isStar = false;
         interact();
      }

      if (!col.gameObject.CompareTag("Star")) return;
      interact();
      isStar = true;
   }

   private void OnTriggerExit(Collider col)
   {
      if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Star"))
      {
         ConversationManager.Instance.EndConversation();
         GameManager.instance.isInDialogue = false;
         ToggleCamera();
      }

      if (col.gameObject.CompareTag("Star"))
      {
         isStar = false;
      }
   }

   public void interact()
   {
      GameManager.instance.isInDialogue = true;
      ToggleCamera();
      if (!isFirstComplete)
      {
         ConversationManager.Instance.StartConversation(_npcFirstConversation);
         
      }
      else
      {
         ConversationManager.Instance.StartConversation(_npcSecondConversation);
      }
   }

   private void ToggleCamera()
   {
      if (isStar)
      {
         if (GameManager.instance.isInDialogue)
         {
            StarCam.SetActive(false);
            playerCam.SetActive(false);
            InteractionCam.SetActive(true);
         }
         else
         {
            StarCam.SetActive(true);
            InteractionCam.SetActive(false);
         }
      }
      else
      {
         if (GameManager.instance.isInDialogue)
         {
            InteractionCam.SetActive(true);
            playerCam.SetActive(false);
            StarCam.SetActive(false);
         }
         else
         {
            playerCam.SetActive(true);
            InteractionCam.SetActive(false);
         }
      }
   }
   
   public void firstComplete()
   {
      FirstConversationAction?.Invoke();
      UIStandart.instance.TitleChange("Pili bul");
      isFirstComplete = true;
      Destroy(wall);
      holeWall.SetActive(true);
   }

   public void isGiveBattery()
   {
      ConversationManager.Instance.SetBool("isGiveBattery",TaskManager.instance.isGiveable);
   }

   public void EndConversation()
   {
      ConversationManager.Instance.EndConversation();
      GameManager.instance.isInDialogue = false;
      Destroy(_boxCollider);
      TaskManager.instance.isGiveBattery = true;
      ToggleCamera();
   }
}
