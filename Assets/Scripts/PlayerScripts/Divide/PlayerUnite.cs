using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerUnite : MonoBehaviour
{
    private PlayerDivideAndUnite _playerDivideAndUnite;
    private PlayerDivide playerDivide;
    private InputManager inputManager;

    private void Awake()
    {
        _playerDivideAndUnite = GetComponent<PlayerDivideAndUnite>();
        playerDivide = GetComponent<PlayerDivide>();
        inputManager = GetComponent<InputManager>();
    }

    private void OnEnable()
    {
        inputManager.ActionUnite += UniteDistance;
    }

    private void OnDisable()
    {
        inputManager.ActionUnite -= UniteDistance;
    }

    public void UniteDistance()
    {
        float goDistance = 1f;
        
        for (int i = _playerDivideAndUnite.cloneList.Count - 1; i >= 0; i--)
        {
            GameObject obj = _playerDivideAndUnite.cloneList[i];
            float distance = Vector3.Distance(transform.position, obj.transform.position);
            
            if (distance < goDistance)
            {
                Unite(obj);
                break; 
            }
        }
    }
    private void Unite(GameObject col)
    {
        _playerDivideAndUnite.lastElement = _playerDivideAndUnite.cloneList.LastOrDefault();
        gameObject.transform.localScale = transform.localScale * 2;
        Destroy(col);
        playerDivide.DivideCount--;
        _playerDivideAndUnite.IncreaseRaycastPosition();
        _playerDivideAndUnite.RemoveLastElement(col);
        _playerDivideAndUnite.SetLastElement();
        SoundEffectManager.Instance.SoundEffect(SoundEffectManager.Instance.uniteClip, true);

    }
}
