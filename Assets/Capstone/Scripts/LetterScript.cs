using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterScript : MonoBehaviour {

    private GameObject letterGameObject;
    // Use this for initialization
    public void OnTriggerEnter(Collider other)
    {
        letterGameObject.GetComponent<Tuple>().justfound();
        gameObject.SetActive(false);

    }
    public void setLetterGameObject(GameObject t)
    {
        this.letterGameObject = t;
    }
}
