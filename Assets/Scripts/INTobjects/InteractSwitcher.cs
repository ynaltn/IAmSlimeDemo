using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InteractSwitcher : MonoBehaviour,IInteractable
{
   
    [SerializeField] protected GameObject InteractObject;
    [SerializeField] protected GameObject Player;
    [SerializeField] protected GameObject InteractObjectModel;
    [SerializeField] protected GameObject PlayerCam;

    private IntObjectInputManager ıntObjectInputManager;

    private void Awake()
    {
        ıntObjectInputManager = GetComponent<IntObjectInputManager>();
    }

    private void OnEnable()
    {
        ıntObjectInputManager.RevertAction += RevertSlime;
    }
    private void OnDisable()
    {
        ıntObjectInputManager.RevertAction -= RevertSlime;
    }
    public void interact()
    {
        SwitchInteractObject();
    }

    protected virtual void RevertSlime()
    {
        Player.SetActive(true);
        PlayerCam.SetActive(true);
        InteractObjectModel.SetActive(true);
        InteractObject.SetActive(false);
    }

    protected virtual void SwitchInteractObject()
    {
        Player.SetActive(false);
        PlayerCam.SetActive(false);
        InteractObjectModel.SetActive(false);
        InteractObject.SetActive(true);
    }
}
