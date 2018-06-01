using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ActiveMenuAideTuto : MonoBehaviour {

    private GameObject[] controllers;
    private bool activate = false;
    public GameObject menu = null;
    public GameObject panel = null;
    public GameObject nextStep;
    private GameObject[] tooltips;
    private bool infosPasse = false;
    private int compteurMsg = 0;

    void Start()
    {
        //tooltips = GameObject.FindGameObjectsWithTag("ToolTips");
        if (controllers == null)
        {
            controllers = new GameObject[2];
            int i = 0;
            foreach(VRTK_ControllerEvents e in GetComponentsInChildren<VRTK_ControllerEvents>())
            {
                controllers[i] = e.gameObject;
                i++; 
            }
            foreach (GameObject c in controllers)
            {
                if (c.GetComponent<VRTK_ControllerHighlighter>())
                {
                    c.GetComponent<VRTK_ControllerHighlighter>().highlightButtonTwo = Color.blue;
                    c.GetComponent<VRTK_ControllerHighlighter>().highlightTouchpad = Color.green;
                    c.GetComponent<VRTK_ControllerHighlighter>().highlightTrigger = Color.red;

                }
            }
        }
        else
        {
            Debug.LogError("Please add VRTK_ControllersEvent");
        }
        SubscribeMenuButton(nextPage);


    }
    public virtual void SubscribeMenuButton(ControllerInteractionEventHandler cieh)
    {
        controllers[0].GetComponent<VRTK_ControllerEvents>().SubscribeToButtonAliasEvent(VRTK_ControllerEvents.ButtonAlias.ButtonTwoPress, false, cieh);
        controllers[1].GetComponent<VRTK_ControllerEvents>().SubscribeToButtonAliasEvent(VRTK_ControllerEvents.ButtonAlias.ButtonTwoPress, false, cieh);      
    }
    public virtual void hideMenu(object sender, ControllerInteractionEventArgs e)
    {
        menu.SetActive(false);
        foreach (GameObject c in controllers)
        {
            c.GetComponent<VRTK_Pointer>().enabled = true;
            c.GetComponent<VRTK_InteractTouch>().enabled = true;
        }
        if(nextStep != null)
        {
            nextStep.SetActive(true);
            nextStep = null;
        }
    }
    public virtual void hideMenuWithoutEnabledPointer(object sender, ControllerInteractionEventArgs e)
    {
        menu.SetActive(false);
        if (nextStep != null)
        {
            nextStep.SetActive(true);
            nextStep = null;
        }
    }

    public virtual void nextPage(object sender, ControllerInteractionEventArgs e)
    {
         if (panel != null)
            {
                Image image = panel.GetComponent<Image>();
                image.sprite = Resources.Load("ScreenMsgDeplacementPhysique", typeof(Sprite)) as Sprite;
            }
            SubscribeMenuButton(hideMenuWithoutEnabledPointer);
    }

    public virtual void resetScene(object sender, ControllerInteractionEventArgs e)
    {
        VRTK_SDKManager.instance.UnloadSDKSetup();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public virtual void returnFormationCenter(object sender, ControllerInteractionEventArgs e)
    {
        SteamVR_LoadLevel.Begin("CentreForma");
    }

    public GameObject[] getControllers()
    {
        return controllers;
    }

    public void setNextStep(GameObject g)
    {
        nextStep = g;
    }

}
