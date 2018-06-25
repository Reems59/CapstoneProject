using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class InteractableLaserPointer : VRTK_InteractableObject {

    private int targetCount = 0;
    //private bool flag = false;
    private Vector3 initLaserPos;
    private Quaternion initLaserRotation;
    private Vector3 initTochPos;
    public GameObject menu;
    private ActiveMenuAideTuto ama;
    private VRTK_Pointer pointer;
    private bool isGrabbOnce = false;

    private void Start()
    {
       // ama = GameObject.Find("VRTK").gameObject.GetComponent<ActiveMenuAideTuto>();
       pointer = gameObject.GetComponent<VRTK_Pointer>();
       pointer.activationButton = VRTK_ControllerEvents.ButtonAlias.TriggerPress;
    }

    public override void Grabbed(VRTK_InteractGrab currentGrabbingObject = null)
    {
        if (!isGrabbOnce)
        {
            initLaserPos = transform.position;
            initLaserRotation = transform.rotation;
            initTochPos = transform.parent.transform.position;
            isGrabbOnce = true;
        }
        base.Grabbed(currentGrabbingObject);
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        pointer.enabled = true;
        //gameObject.GetComponent<VRTK_StraightPointerRenderer>().enabled = true;
        pointer.customOrigin = gameObject.transform.Find("LaserOrigin").transform;
        pointer.controller = currentGrabbingObject.GetComponent<VRTK_ControllerEvents>();
        pointer.interactUse = currentGrabbingObject.GetComponent<VRTK_InteractUse>();

    }

    public override void Ungrabbed(VRTK_InteractGrab previousGrabbingObject = null)
    {
        base.Ungrabbed(previousGrabbingObject);
        gameObject.transform.position = initLaserPos;
        gameObject.transform.rotation = initLaserRotation;
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        validDrop = ValidDropTypes.NoDrop;
    }

    public void resetLaserBehaviour()
    {
        validDrop = ValidDropTypes.DropAnywhere;

        //
        //pointer.enabled = false;
        //Ungrabbed();


    }
    /*protected override void Update()
    {
        base.Update();
        if (IsGrabbed())
        {

        }

    }*/
}
