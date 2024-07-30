using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IntObjTextChanger : MonoBehaviour
{

    [SerializeField] private float spendTime;
    [SerializeField] private string warningMessage;
    private void OnDisable()
    {
        spendTime = 0;
        UIStandart.instance.ShowPlayerTextWindow(UIStandart.instance.playerTextTitle.text,"");
    }

    private void Update()
    {
        CalculateTime();
       
    }

    private void CalculateTime()
    {
        spendTime += Time.deltaTime;
        if (spendTime > 20)
        {
            UIStandart.instance.ShowPlayerTextWindow(UIStandart.instance.playerTextTitle.text,warningMessage);
            
        }
    }

   
}
