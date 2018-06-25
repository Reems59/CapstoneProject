using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class MyClock : MonoBehaviour
{
    public int Minutes = 10;
    public int Seconds = 0;

    private Text m_text;
    private float m_leftTime;

    public GameObject menu;
    private MenuScript menuScript;

    private void Awake()
    {
        m_text = GetComponent<Text>();
        m_leftTime = GetInitialTime();
    }

    public void Start()
    {
        menuScript = menu.GetComponent<MenuScript>();

    }

    private void Update()
    {
        if (m_leftTime > 0f)
        {
            //  Update countdown clock
            m_leftTime -= Time.deltaTime;
            Minutes = GetLeftMinutes();
            Seconds = GetLeftSeconds();

            //  Show current clock
            if (m_leftTime > 0f)
            {
                m_text.text = "Time : " + Minutes + ":" + Seconds.ToString("00");
            }
            else
            {
                Image image = menu.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Image>();
                image.sprite = Resources.Load("LooseScreen", typeof(Sprite)) as Sprite;
                menuScript.SubscribeMenuButton(menuScript.looseMenu);
                foreach( GameObject g in menuScript.controllers)
                {
                    g.GetComponent<VRTK_InteractTouch>().enabled = false;

                }
                menu.transform.GetChild(0).gameObject.SetActive(true);
                //  The countdown clock has finished
                m_text.text = "Time : 0:00";
            }
        }
    }

    private float GetInitialTime()
    {
        return Minutes * 60f + Seconds;
    }

    private int GetLeftMinutes()
    {
        return Mathf.FloorToInt(m_leftTime / 60f);
    }

    private int GetLeftSeconds()
    {
        return Mathf.FloorToInt(m_leftTime % 60f);
    }
}