using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ActiveBallButton : VRTK_InteractableObject
{

    public GameObject ball;

    public override void StartUsing(VRTK_InteractUse currentUsingObject = null)
    {
        base.StartUsing(currentUsingObject);
        Rigidbody rg = ball.GetComponent<Rigidbody>();
        if (rg.constraints != RigidbodyConstraints.None)
        {
            ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
