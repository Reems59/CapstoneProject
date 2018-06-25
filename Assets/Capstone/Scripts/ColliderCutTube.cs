using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCutTube : MonoBehaviour {

    public GameObject crate;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sharp"))
        {
            crate.AddComponent<Rigidbody>();
            gameObject.SetActive(false);
        }
    }
}
