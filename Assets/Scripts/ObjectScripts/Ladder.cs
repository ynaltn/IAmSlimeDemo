using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour,IInteractable
{
    [SerializeField] private PlayerLocomotion playerLocomotion;

    public void interact()
    {
        playerLocomotion.isClimbing = true;
    }
}
