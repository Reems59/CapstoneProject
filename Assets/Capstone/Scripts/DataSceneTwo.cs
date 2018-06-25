using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSceneTwo : MonoBehaviour {

    public ScenePatriManager spm;

    public void Start()
    {
        spm = FindObjectOfType<ScenePatriManager>();
        spm.LoadLevelInfo();
    }
}
