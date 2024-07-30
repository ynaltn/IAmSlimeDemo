using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerInteract : MonoBehaviour
{
    private InputManager inputManager;
    [SerializeField] private LayerMask interactMask;
    public RaycastHit hit;
    [SerializeField] private float rayMaxDistance=4f;
   // [SerializeField] private Transform rayDirection;
   [SerializeField] private Vector3 BoxSize; 
   [SerializeField]private Transform spherePosition;
  

   private void Awake()
    {
        inputManager = GetComponent<InputManager>();
    }

    private void OnEnable()
    {
        inputManager.ActionInteract += Interact;
    }

    private void OnDisable()
    {
        inputManager.ActionInteract -= Interact;
    }

    private void Interact()
    {
        // Debug.DrawRay(rayDirection.position, rayDirection.forward * rayMaxDistance, Color.red);
        // if (Physics.Raycast(rayDirection.position, rayDirection.forward,out hit, rayMaxDistance, interactMask))
        // {
        //     if (hit.collider.TryGetComponent(out IInteractable interactObject))
        //     {
        //         interactObject.interact();
        //     }
        // }
        
        Vector3 origin = spherePosition.position;
        Vector3 halfExtents = BoxSize / 2;
        Vector3 direction = spherePosition.forward;
        Quaternion orientation = spherePosition.rotation;
        

        if (Physics.BoxCast(origin, halfExtents, direction, out hit, orientation, rayMaxDistance, interactMask))
        {
           
            if (hit.collider.TryGetComponent(out IInteractable interactObject))
            {
                interactObject.interact();
            }
        }
     
    }

    // private void OnDrawGizmos()
    // {
    //     if (spherePosition == null) return;
    //
    //     Gizmos.color = Color.red;
    //     Vector3 origin = spherePosition.position;
    //     Vector3 halfExtents = BoxSize / 2;
    //     Vector3 direction = spherePosition.forward * rayMaxDistance;
    //
    //     Gizmos.DrawWireCube(origin + direction / 2, BoxSize);
    // }
}
