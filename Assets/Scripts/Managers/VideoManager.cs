using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    
    [SerializeField] private VideoPlayer videoPlayer;

    public VideoClip[] clips;
    public GameObject globalVolume;

    [SerializeField] private bool isDead;
    [SerializeField] private Camera playerCam;
    [SerializeField] private Camera robotCam;
    
    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    private void Start()
    {
        PlayVideo(clips[0],false,playerCam);
    }

    private void OnEnable()
    {
        LampButtonInteract.LampButtonAction += () => PlayVideo(clips[1], true,playerCam).Forget();
        RobotInteraction.FirstConversationAction += () => PlayVideo(clips[2], false,robotCam).Forget();
        CutSceneTrigger.BabyOilCutscene+=() => PlayVideo(clips[3],false,playerCam).Forget();
        ParkurCutscene.ParkurCutSceneAction+=() => PlayVideo(clips[4],false,playerCam).Forget();

    }

    private void OnDisable()
    {
        LampButtonInteract.LampButtonAction -= () => PlayVideo(clips[1], true,playerCam).Forget();
        RobotInteraction.FirstConversationAction -= () => PlayVideo(clips[2], false,robotCam).Forget();
        CutSceneTrigger.BabyOilCutscene-=() => PlayVideo(clips[3],false,playerCam).Forget();
        ParkurCutscene.ParkurCutSceneAction-=() => PlayVideo(clips[4],false,playerCam).Forget();
    }

    private async UniTaskVoid PlayVideo(VideoClip clip,bool isdead,Camera cam)
    {
        await UniTask.Yield();
        isDead = isdead;
        videoPlayer.clip = clip;
        videoPlayer.targetCamera = cam;
        videoPlayer.Play();
        globalVolume.SetActive(false);
        videoPlayer.loopPointReached += OnFinishedVideo;
        GameManager.instance.isInCutscene = true;
        
    }

    private void OnFinishedVideo(VideoPlayer vp)
    {
        vp.Stop();
        GameManager.instance.isDead = isDead;
        videoPlayer.loopPointReached -= OnFinishedVideo;
        GameManager.instance.isInCutscene = false;
        globalVolume.SetActive(true);
       
    }
   
}