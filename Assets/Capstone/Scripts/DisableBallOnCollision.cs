using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableBallOnCollision : MonoBehaviour {

    private Vector3 initialPosition;
    private Rigidbody rb;
    private AudioSource audioS;

    void Start()
    {
        initialPosition = gameObject.transform.position;
        rb = gameObject.GetComponent<Rigidbody>();
        audioS = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            audioS.Play();
            resetBall();
        }
            
    }

    public void resetBall()
    {
        gameObject.transform.position = initialPosition;
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        gameObject.SetActive(true);
    }

    public void Update()
    {

        if (Mathf.Approximately(rb.velocity.x, 0)
            && Mathf.Approximately(rb.velocity.y, 0) && Mathf.Approximately(rb.velocity.z, 0))
        {
            resetBall();
        }
    }
}
