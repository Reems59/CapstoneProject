using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ActiveCode : VRTK_InteractableObject {

    private bool actived = false;
    public GameObject canvas;

    public override void StartUsing(VRTK_InteractUse currentUsingObject = null)
    {
        base.StartUsing(currentUsingObject);
        if (!actived)
        {
            canvas.SetActive(true);
            actived = true;
        }else
        {
            canvas.SetActive(false);
            actived = false;
        }
    }
}
