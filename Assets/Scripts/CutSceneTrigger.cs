using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneTrigger : MonoBehaviour
{
    public static Action BabyOilCutscene;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            BabyOilCutscene?.Invoke();
            UIStandart.instance.TitleChange("Bebek yağına ulasmalıyım");
            Destroy(gameObject,8f);
        }
    }
}
