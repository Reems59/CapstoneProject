using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class InteractableTarget : VRTK_InteractableObject {

    public GameObject laser;
    public GameObject plateforme;
    public GameObject button;
    private InteractableLaserPointer ilp;
    private bool IsShoot = false;

    public void Start()
    {
        ilp = laser.GetComponent<InteractableLaserPointer>();
    }

    public override void StartUsing(VRTK_InteractUse currentUsingObject = null)
    {
        base.StartUsing(currentUsingObject);
        if (ilp.IsGrabbed() && !IsShoot)
        {
            currentUsingObject.GetComponent<VRTK_ControllerActions>().TriggerHapticPulse(1f, 0.1f, 0.01f);
            button.GetComponent<Renderer>().material.color = Color.green;
            plateforme.GetComponent<Animation>().Play();
            ilp.resetLaserBehaviour();
            IsShoot = true;
        }
    }

    public void setIsShoot(bool shoot)
    {
        IsShoot = shoot;
    }

    public bool GetisShoot()
    {
        return IsShoot;
    }
}
