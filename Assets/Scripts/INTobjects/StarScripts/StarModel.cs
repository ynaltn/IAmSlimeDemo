using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarModel : MonoBehaviour,IInteractable
{
    [SerializeField] private StarInteraction _starInteraction;


    public void interact()
    {
        _starInteraction.interact();
    }
}
