using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.UI;


public class MenuScript : MonoBehaviour
{

    public GameObject[] controllers;
    private GameObject canvasMenu;
    private bool menuPlayed = false;

    public void Start()
    {
        canvasMenu = gameObject.transform.GetChild(0).gameObject;
        if (!menuPlayed)
        {
            menuPlayed = true;
            canvasMenu.SetActive(true);
            SubscribeMenuButton(hideMenuWithoutEnabledPointer);
        }
        
    }

    public virtual void SubscribeMenuButton(ControllerInteractionEventHandler cieh)
    {
        controllers[0].GetComponent<VRTK_ControllerEvents>().SubscribeToButtonAliasEvent(VRTK_ControllerEvents.ButtonAlias.ButtonTwoPress, false, cieh);
        controllers[1].GetComponent<VRTK_ControllerEvents>().SubscribeToButtonAliasEvent(VRTK_ControllerEvents.ButtonAlias.ButtonTwoPress, false, cieh);
    }

    public virtual void looseMenu(object sender, ControllerInteractionEventArgs e)
    {
        Application.Quit();
        
    }
    public virtual void hideMenuWithoutEnabledPointer(object sender, ControllerInteractionEventArgs e)
    {
        GetComponent<AudioSource>().Play();
        canvasMenu.SetActive(false);
    }
}