using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourBallSceneThree : MonoBehaviour {

    private string lastTagCollisionned;
    private Vector3 initialPosition;
    private Rigidbody rb;
    public PopBall popBallButton;

    public void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        initialPosition = gameObject.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        lastTagCollisionned = collision.gameObject.tag;
    }

    public void Update()
    {
        if (rb.velocity.x < 1f
            && rb.velocity.y < 1f && rb.velocity.z < 1f && lastTagCollisionned == "Ground")
        {
            resetBall();
        }
    }

    public void resetBall()
    {
        gameObject.transform.position = initialPosition;
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        popBallButton.setBallThrowed(false);
        lastTagCollisionned = "";

    }
}
