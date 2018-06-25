using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveFan : MonoBehaviour {

    public GameObject fan;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Throwable"))
        {
            fan.GetComponent<RotateBlade>().enabled = true;
            GetComponent<AudioSource>().Play();

        }
    }
}
