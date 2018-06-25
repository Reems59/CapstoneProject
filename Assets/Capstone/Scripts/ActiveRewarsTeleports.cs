using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveRewarsTeleports : MonoBehaviour {

    public GameObject rewards;
    public GameObject teleports;
    // Use this for initialization
    void Start()
    {
        rewards.transform.GetChild(0).gameObject.SetActive(true);
        rewards.transform.GetChild(1).gameObject.SetActive(true);
        teleports.SetActive(true);
    }
}
