using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryInteract : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Star"))
        {
            gameObject.transform.SetParent(col.transform);
            UIStandart.instance.TitleChange("Pili Robota Götür");
        }
        else if (col.gameObject.CompareTag("Robot"))
        {
            TaskManager.instance.isGiveable = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Robot"))
        {
            TaskManager.instance.isGiveable = false;
            
        }
    }

    public void DestroyBattery()
    {
        
        Destroy(gameObject);
    }
}
