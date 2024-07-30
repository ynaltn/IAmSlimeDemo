using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2Interact : MonoBehaviour
{
    [SerializeField]private GameObject gameObject;
    [SerializeField] private string message;

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(true);
        UIStandart.instance.ShowPlayerTextWindow("",message);
    }
    
}
