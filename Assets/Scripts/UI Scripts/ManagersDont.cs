using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagersDont : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
