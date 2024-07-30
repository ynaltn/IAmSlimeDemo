using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
   public static SoundEffectManager Instance;

   public AudioSource aSource;
   [Header("PlayerSoundEffect")]
   public AudioClip uniteClip;
   public AudioClip divideClip;
   public AudioClip teleportClip;
   [Header("InteractableSoundEffect")]
   public AudioClip cannonShootClip;
   public AudioClip lampOnOffClip;
   
   private void Awake()
   {
      aSource = GetComponent<AudioSource>();
      if (Instance == null)
      {
         Instance = this;
      }
      else
      {
         Destroy(gameObject);
      }
   }
   
   public void SoundEffect(AudioClip audioClip,bool isPlayable)
   {
      if(!isPlayable) return;
      aSource.clip = audioClip;
      aSource.PlayOneShot(audioClip);
      
   }
}
