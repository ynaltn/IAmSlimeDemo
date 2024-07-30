using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class StarInteraction : InteractSwitcher
{
   [SerializeField] private GameObject light;
   [SerializeField] private float lightyPosition;
    protected override void RevertSlime()
    {
        
        UpdatePosition().Forget();
    }

    protected override void SwitchInteractObject()
    {
        base.SwitchInteractObject();
        var newPosition = InteractObject.transform.position;
        newPosition.y = newPosition.y + lightyPosition;
        light.transform.SetParent(InteractObject.transform);
        light.transform.position = newPosition;

    }

    private async UniTaskVoid UpdatePosition()
    {
        await UniTask.WaitForFixedUpdate();
        if (Player != null && InteractObjectModel != null)
        {
            var position = InteractObject.transform.position;
            Player.transform.position = position;
            InteractObjectModel.transform.position = position;
            light.transform.SetParent(InteractObjectModel.transform);
            base.RevertSlime();
        }


    }
}
