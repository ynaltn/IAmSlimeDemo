using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private InputManager _inputManager;
    private PlayerLocomotion _playerLocomotion;
    public CameraManager cameraManager;
    public Animator animator;


    public bool isInteracting;
    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _playerLocomotion = GetComponent<PlayerLocomotion>();
        animator=GetComponent<Animator>();
        DontDestroyOnLoad(gameObject);
    }
    
    void Update()
    {
        if(GameManager.instance.isDead) return;
        if(GameManager.instance.isInCutscene) return;
        if(GameManager.instance.isGameStop) return;
        _inputManager.HandleAllInput();
    }

    private void FixedUpdate()
    {
        if(GameManager.instance.isGameStop) return;
       if(GameManager.instance.isInCutscene) return;
        _playerLocomotion.HandleAllMovement();
    }

    private void LateUpdate()
    {
        cameraManager.HandleAllCameraMovement();
        isInteracting= animator.GetBool("isInteracting");
        _playerLocomotion.isJumping = animator.GetBool("isJumping");
        animator.SetBool("isGrounded",_playerLocomotion.isGrounded);
        animator.SetBool("isClimbing",_playerLocomotion.isClimbing);
    }

}
