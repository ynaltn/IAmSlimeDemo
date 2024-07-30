using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonModel : MonoBehaviour,IInteractable
{
    [SerializeField] private InteractSwitcher _cannonInteract;
    public void interact()
    {
        _cannonInteract.interact();
    }
}
