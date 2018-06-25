using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        Application.Quit();
    }
}
