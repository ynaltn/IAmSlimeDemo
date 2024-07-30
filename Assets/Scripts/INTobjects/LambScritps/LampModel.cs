using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampModel : MonoBehaviour,IInteractable
{
    [SerializeField] private InteractSwitcher lampInteraction;
    public void interact()
    {
        lampInteraction.interact();
    }
}
