using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedirectionScript : MonoBehaviour {

    public string scene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Body"))
        {
            SteamVR_LoadLevel.Begin(scene);

        }
    }
}
