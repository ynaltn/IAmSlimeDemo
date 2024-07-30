using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotator : MonoBehaviour
{
    public Vector3 Amount = new Vector3(0, 0, 30);
   
  
    void Update()
    {
       transform.Rotate(Amount*Time.deltaTime);
    }
}
