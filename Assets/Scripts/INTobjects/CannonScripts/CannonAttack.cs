using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class CannonAttack : MonoBehaviour
{
    private IntObjectInputManager ıntObjectInputManager;
    
    [SerializeField]
    private Transform bulletSpawnPoint;

    [SerializeField]
    private CannonBall cannonBall;

     [SerializeField] private Transform cannonHead;

    Cinemachine.CinemachineImpulseSource source;

     
     public CinemachineVirtualCamera cam;
    private void Awake()
    {
        ıntObjectInputManager = GetComponent<IntObjectInputManager>();
        source = GetComponent<CinemachineImpulseSource>();
        

    }

    private void OnEnable()
    {
        ıntObjectInputManager.R1Action += Attack;
    }

    private void OnDisable()
    {
        ıntObjectInputManager.R1Action -= Attack;
    }

    void Attack()
    {
        cannonBall.addCannonBall(bulletSpawnPoint,cannonHead.transform.rotation);
       // SoundEffectManager.Instance.SoundEffect(SoundEffectManager.Instance.cannonShootClip,true);
        //source.GenerateImpulse(transform.up);
        source.GenerateImpulse(cam.transform.up);
    }
    
 
}
