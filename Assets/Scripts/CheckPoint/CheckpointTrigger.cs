using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    public static Action<Vector3> TriggerAction;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            TriggerAction?.Invoke(transform.position);
        }
    }
}
