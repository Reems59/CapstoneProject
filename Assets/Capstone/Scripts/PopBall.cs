using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PopBall : VRTK_InteractableObject {

    private bool ballThrowed = false;
    public DataSceneThree dataSceneThree;
    public GameObject ball;
    private Vector3 posBall;
    private Rigidbody ballRigidBody;
    public float ballSpeed = 10f;

    public void Start()
    {
        posBall = ball.transform.position;
        ballRigidBody = ball.GetComponent<Rigidbody>();

    }

    public override void StartUsing(VRTK_InteractUse currentUsingObject = null)
    {
        base.StartUsing(currentUsingObject);
        if (!ballThrowed && !dataSceneThree.needInstanceBall)
        {
            initialBall();
        }
        else if (dataSceneThree.needInstanceBall && !ballThrowed)
        {
            ball = Instantiate(ball);
            ballRigidBody = ball.GetComponent<Rigidbody>();
            ball.transform.position = posBall;
            initialBall();
        }
    }

    public void initialBall()
    {
        ballThrowed = true;
        ballRigidBody.constraints = RigidbodyConstraints.None;
        ballRigidBody.velocity = (-Vector3.forward * ballSpeed);
    }

    public void setBallThrowed(bool bol)
    {
        ballThrowed = bol;
    }
}
