using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSceneOne : MonoBehaviour {

    public ScenePatriManager spm;

    public void Start()
    {
        spm = FindObjectOfType<ScenePatriManager>();
        spm.LoadLevelInfo();
    }

}
