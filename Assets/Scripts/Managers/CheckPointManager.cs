using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPointManager : MonoBehaviour,ISceneChange
{
    private PlayerSceneChangeManager _playerSceneChangeManager;
    private Vector3 checkPointPosition;
    private bool checkPointSet=false;
    public GameObject player;
    public GameObject restartCanvas;


    private void Awake()
    {
        _playerSceneChangeManager = GetComponent<PlayerSceneChangeManager>();
    }

    private void OnEnable()
    {
        CheckpointTrigger.TriggerAction += SetCheckPoint;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        CheckpointTrigger.TriggerAction -= SetCheckPoint;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void SetCheckPoint(Vector3 NewPosition)
    {
        checkPointPosition = NewPosition;
        checkPointSet = true;
        Debug.Log("Checkpoint set to: " + checkPointPosition);
    }

    private Vector3 GetCheckPoint()
    {
        return checkPointPosition;
    }

    private bool IsCheckpointSet()
    {
        return checkPointSet;
    }
    public void RespawnPlayer()
    {
        if (IsCheckpointSet())
        {
            UpdatePosition().Forget();
        }
        else
        {
            //Debug.LogWarning("No checkpoint set.");
        }
    }

    private  async UniTaskVoid UpdatePosition()
    {
        await UniTask.WaitForFixedUpdate();
        Vector3 respawnPosition = GetCheckPoint();
        player.transform.position = respawnPosition;
        GameManager.instance.isDead = false;
        //Debug.Log("Player respawned at: " + respawnPosition);
    }

    private void OpenCanvas()
    {
        restartCanvas.SetActive(true);
    }

    private void CloseCanvas()
    {
        restartCanvas.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.instance.isDead)
        {
            OpenCanvas();
        }
        else
        {
            CloseCanvas();
        }
      
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
      if(_playerSceneChangeManager.scenePositions.TryGetValue(scene.name,out var initialPosition))
      {
          SetCheckPoint(initialPosition);
        //  Debug.Log($"Checkpoint set to initial position for scene {scene.name}: {initialPosition}");
      }
      else
      {
         // Debug.LogWarning($"Scene '{scene.name}' not found in scenePositions dictionary.");

      }
    }
}
