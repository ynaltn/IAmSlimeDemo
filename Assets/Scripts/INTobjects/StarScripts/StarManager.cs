using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class StarManager : MonoBehaviour
{
    private StarLocomotion _starLocomotion;
    private StarInputManager _starInputManager;
     [SerializeField] private GameObject starCamera;

    private void OnEnable()
    {
        starCamera.SetActive(true);
    }

    private void Awake()
    {
        _starLocomotion = GetComponent<StarLocomotion>();
        _starInputManager = GetComponent<StarInputManager>();
    }

    private void Update()
    {
        _starInputManager.HandleAllInput();
    }
    
    private void FixedUpdate()
    {
       
        _starLocomotion.HandleAllMovement();
    }
}
