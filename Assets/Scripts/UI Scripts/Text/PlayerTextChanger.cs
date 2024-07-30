using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class PlayerTextChanger : MonoBehaviour
{
    [SerializeField] private string Message;
    [SerializeField] private string Title;
    private BoxCollider _boxCollider;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            UIStandart.instance.ShowPlayerTextWindow(Title,Message);
            HidePlayerText().Forget();
        }
    }
    public async UniTaskVoid HidePlayerText()
    {
        await UniTask.Delay(4000);
        UIStandart.instance.PlayerTextMessage.text = "";
        Message = "";
        Destroy(_boxCollider);
       // Title = "";

    }
    
    
}
