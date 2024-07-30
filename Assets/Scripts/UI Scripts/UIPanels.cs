using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIPanels : MonoBehaviour,ISceneChange
{

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UIStandart.instance.ShowLoading("Yükleniyor...", "Lütfen bekleyin");
        GameManager.instance.isInCutscene = true;
        HideLoading().Forget();
    }

    private async UniTaskVoid HideLoading()
    {
        await UniTask.Delay(2000);
        //GameManager.instance.isInCutscene = false; //build alırken kapa
        UIStandart.instance.HideLoading();
    }
    
}
