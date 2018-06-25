using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableBlock : MonoBehaviour {

    public GameObject block,block2;
    private bool activate = false;
    public Material m;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Throwable") && !activate)
        {
            block.GetComponent<Animation>().Play();
            block2.GetComponent<Animation>().Play();
            Material[] mats = gameObject.GetComponent<MeshRenderer>().materials;
            mats[0] = m;
            GetComponent<Renderer>().materials = mats;
            activate = true;
            GetComponent<AudioSource>().Play();

        }
    }
}
