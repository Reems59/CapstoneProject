using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ActivePlatLaser : VRTK_InteractableObject {

    public Animation plateforme1, plateforme2;
    private bool actived = false;
    public AnimationClip a1, a2;
    private AnimationClip initA1, initA2;
    private Animation p1, p2;


    public void Start()
    {
        p1 = plateforme1.GetComponent<Animation>();
        p2 = plateforme2.GetComponent<Animation>();
        initA1 = p1.clip;
        initA2 = p2.clip;
    }
    public override void StartUsing(VRTK_InteractUse currentUsingObject = null)
    {
        base.StartUsing(currentUsingObject);
        p1.Play();
        p2.Play();
        if (!actived)
        {
            p1.clip = p1.GetClip("InverseRotateTrappe");
            p2.clip = p2.GetClip("AppearPlat1");
            actived = true;
        }else
        {
            p1.clip = initA1;
            p2.clip = initA2;
            actived = false;
        }
       

    }
}
