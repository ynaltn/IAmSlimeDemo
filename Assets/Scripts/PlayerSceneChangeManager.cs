using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSceneChangeManager : MonoBehaviour,ISceneChange
{
    public  Dictionary<string, Vector3> scenePositions = new Dictionary<string, Vector3>
    {
        { "Room", new Vector3(45, 0, 44) },
        { "Parkur", new Vector3(37, 14, -2) },
    };

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

   public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetPlayerPosition(scene).Forget();
    }

    private async UniTaskVoid SetPlayerPosition(Scene scene)
    {
        await UniTask.DelayFrame(20);
       
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null && scenePositions.TryGetValue(scene.name, out var position))
        {
            await UniTask.WaitForFixedUpdate();
            Debug.Log($"Setting position for scene {scene.name}");
            player.transform.position = position;
            Debug.Log($"Player new position: {player.transform.position}");
        }
        else
        {
            Debug.LogWarning($"Scene '{scene.name}' is not in the dictionary or player not found.");
        }
    }
}