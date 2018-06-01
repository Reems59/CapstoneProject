using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class InteractableTarget : VRTK_InteractableObject {

    public GameObject laser;
    


    public override void StartUsing(VRTK_InteractUse currentUsingObject = null)
    {
        base.StartUsing(currentUsingObject);
        /*if (laser.GetComponent<InteractableLaserPointer>().IsGrabbed())
        {
            currentUsingObject.GetComponent<VRTK_ControllerActions>().TriggerHapticPulse(1f, 0.1f, 0.01f);
            GetComponent<AudioSource>().Play();
            transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
            gameObject.GetComponent<Renderer>().material.color = Color.black;
            Destroy(gameObject.GetComponent<CapsuleCollider>());
            laser.GetComponent<InteractableLaserPointer>().TargetDestroy();
        }*/
    }
}
