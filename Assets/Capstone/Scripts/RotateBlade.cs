using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBlade : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, Time.deltaTime * 200f, 0));
    }
}
