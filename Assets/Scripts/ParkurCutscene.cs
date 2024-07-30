using UnityEngine;
using System;
public class ParkurCutscene : MonoBehaviour
{
    public static Action ParkurCutSceneAction;
    void Start()
    {
        ParkurCutSceneAction?.Invoke();
    }
    
}
