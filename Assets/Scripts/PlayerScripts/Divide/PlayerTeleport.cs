using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private PlayerDivide playerDivide;
    private InputManager inputmanager;
    private AnimatorManager animatorManager;
    private PlayerDivideAndUnite _playerDivideAndUnite;
    
    private void Awake()
    {
        inputmanager = GetComponent<InputManager>();
        animatorManager = GetComponent<AnimatorManager>();
        _playerDivideAndUnite = GetComponent<PlayerDivideAndUnite>();

    }

    private void OnEnable()
    {
        inputmanager.ActionTeleport += Teleport;
        
    }

    private void Teleport()
    {
        if (!_playerDivideAndUnite.CloneListIsEmpty()) return;
        animatorManager.PlayTargetAnimation("Teleport", true);
        
        Vector3 clonePosition = _playerDivideAndUnite.lastElement.transform.position;
        
        //StartCoroutine(MoveToPosition(clonePosition));
        MoveToPosition(clonePosition).Forget();

        SoundEffectManager.Instance.SoundEffect(SoundEffectManager.Instance.teleportClip, true);


    }
   /*private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        float elapsedTime = 0f;
        float moveTime = 0.1f; 

        Vector3 startingPosition = transform.position;

        while (elapsedTime < moveTime)
        {
            elapsedTime += Time.deltaTime;
            
            transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / moveTime);

            yield return null;
        }
        transform.position = targetPosition;
    }*/

   private async UniTaskVoid MoveToPosition(Vector3 targetPosition)
   {
       float elapsedTime = 0f;
       float moveTime = 0.1f; 

       Vector3 startingPosition = transform.position;

       while (elapsedTime < moveTime)
       {
           await UniTask.WaitForFixedUpdate();
           elapsedTime += Time.deltaTime;
            
         
           transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / moveTime);

           await UniTask.Yield();
       }
       transform.position = targetPosition;
   }
}
