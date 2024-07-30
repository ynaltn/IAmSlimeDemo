using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollide : MonoBehaviour
{
   [SerializeField] private Transform Ground;
   [SerializeField] private float duration = 2.0f;
   [SerializeField] private Transform Star;
   private void OnCollisionEnter(Collision col)
   {
      if (col.gameObject.CompareTag("Ball"))
      {
         StartCoroutine(MoveToGround());
      }
   }

   private IEnumerator MoveToGround()
   {
      Vector3 startPos = Star.position;
      Vector3 endPos = Ground.position;
      float elapsedTime = 0;

      while (elapsedTime < duration)
      {
         transform.position = Vector3.Slerp(startPos, endPos, elapsedTime / duration);
         transform.rotation = Ground.rotation;
         elapsedTime += Time.deltaTime;
         yield return null; 
      }
      Star.position = endPos;
      transform.position = endPos;

   }
}
