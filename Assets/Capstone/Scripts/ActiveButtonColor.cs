using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveButtonColor : MonoBehaviour {

    public DataSceneThree ds3;
    public PopBall popBallScript;
    private bool isTouched = false;
    private Animation tube, coffre;
    public Material material;

    public void Start()
    {
        tube = ds3.getTube();
        coffre = ds3.getCoffre();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Throwable") && !isTouched)
        {
            ds3.increaseTargetActivate();
            GetComponent<AudioSource>().Play();
            isTouched = true;
            GetComponent<Renderer>().material = material;
            ds3.needInstanceBall = true;
            popBallScript.setBallThrowed(false);
            if (ds3.getNbTargetActivate() == 3)
            {
                tube.Play();
                coffre.Play();
            }
          
        }
    }
}
