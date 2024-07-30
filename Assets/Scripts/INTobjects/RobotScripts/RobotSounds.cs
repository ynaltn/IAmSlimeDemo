using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSounds : MonoBehaviour
{
    
    [SerializeField] private AudioClip robotSound;
    [SerializeField] private AudioClip robotAngrySound;


    public void playRobotSound()
    {
        SoundEffectManager.Instance.SoundEffect(robotSound,true);
    }
    public void playAngrySound()
    {
        SoundEffectManager.Instance.SoundEffect(robotAngrySound,true);
    }
}
