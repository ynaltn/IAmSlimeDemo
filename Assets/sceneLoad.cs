using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoad : MonoBehaviour
{
    public string SceneName;
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(SceneName);
    }
}
