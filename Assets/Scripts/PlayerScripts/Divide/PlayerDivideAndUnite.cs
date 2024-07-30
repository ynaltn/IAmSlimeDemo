using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerDivideAndUnite : MonoBehaviour
{
    public List<GameObject> cloneList= new List<GameObject>();
    public GameObject lastElement;
    private PlayerLocomotion playerLocomotion;

    private void Awake()
    {
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    public void addElementOnList(GameObject go)
    {
        cloneList.Add(go);
    }

    public void SetLastElement()
    {
        lastElement = cloneList.LastOrDefault();
    }

    public void RemoveLastElement(GameObject go)
    {
        cloneList.Remove(go);
    }

    public bool CloneListIsEmpty()
    {
        return cloneList.Any() && lastElement != null;
    }

    public void DecreaseRaycastPosition()
    {
       /* var heightOffSet = playerLocomotion.raycastHeightOffset-0.2f;
        playerLocomotion.raycastHeightOffset = heightOffSet;*/
        
        
    }
    public void  IncreaseRaycastPosition ()
    {

        /*var heightOffSet = playerLocomotion.raycastHeightOffset+0.2f;
        playerLocomotion.raycastHeightOffset = heightOffSet;*/
        
    }
}