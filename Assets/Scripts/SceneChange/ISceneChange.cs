using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public interface ISceneChange
{
    void OnSceneLoaded(Scene scene, LoadSceneMode mode);
}
