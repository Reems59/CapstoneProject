using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOnGround : MonoBehaviour {

    public GameObject crateExplode;
    public GameObject teleporters;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            crateExplode.transform.rotation = gameObject.transform.rotation;
            crateExplode.transform.position = gameObject.transform.position;
            /*Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;*/
            crateExplode.SetActive(true);
            gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.SetActive(true);
            teleporters.SetActive(true);
        }

    }
}
