using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour {

    private Vector3 initialPosition;
    private Rigidbody rb;
    public InteractableTarget itTarget;
    public GameObject button;
    public GameObject plateforme;

    void Start()
    {
        initialPosition = gameObject.transform.position;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            resetBall();
            resetMecanism();
        }

    }

    public void resetBall()
    {
        gameObject.transform.position = initialPosition;
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void resetMecanism()
    {
        itTarget.setIsShoot(false);
        button.GetComponent<Renderer>().material.color = Color.red;
        plateforme.transform.rotation = Quaternion.identity;

    }

    public void Update()
    {

        if (Mathf.Approximately(rb.velocity.x, 0)
            && Mathf.Approximately(rb.velocity.y, 0) && Mathf.Approximately(rb.velocity.z, 0) && itTarget.GetisShoot())
        {
            resetBall();
        }
    }
}
