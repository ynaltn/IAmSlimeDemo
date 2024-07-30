using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Star"))
        {
            if (TaskManager.instance.isGiveBattery)
            {
                SceneManager.LoadScene(sceneName);
                UIStandart.instance.TitleChange("");
            }
        }
    }
}
