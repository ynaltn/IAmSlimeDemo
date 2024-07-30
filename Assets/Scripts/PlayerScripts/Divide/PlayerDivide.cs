using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class PlayerDivide : MonoBehaviour
{
    private PlayerDivideAndUnite _playerDivideAndUnite;
    
    private int divideCount=0;
    public bool isDivide=true;
    [SerializeField] private GameObject clonee;
    private InputManager inputManager;

    private void Awake()
    {
        _playerDivideAndUnite = GetComponent<PlayerDivideAndUnite>();
        inputManager = GetComponent<InputManager>();
    }

    private void OnEnable()
    {
        inputManager.ActionDivide += Divide;
    }

    private void OnDisable()
    {
        inputManager.ActionDivide -= Divide;
    }

    public int DivideCount
    {
        get
        {
            return divideCount;
        }
        set
        {
            divideCount = value;
            if (value >= 2)
            {
                isDivide = false;
            }
            else
            {
                isDivide = true;
            }
        }
    }

   
    
    public void Divide()
    {
        if (!isDivide)  return;
        DivideCount++;
        transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z / 2);
        GameObject clone = Instantiate(clonee, transform.position,quaternion.identity);
        clone.transform.localScale = transform.localScale;
        _playerDivideAndUnite.DecreaseRaycastPosition();
        SoundEffectManager.Instance.SoundEffect(SoundEffectManager.Instance.divideClip,true);
        _playerDivideAndUnite.addElementOnList(clone);
        _playerDivideAndUnite.SetLastElement();

    }
   
 
    
   
    
}
