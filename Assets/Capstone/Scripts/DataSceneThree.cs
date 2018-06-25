using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSceneThree : MonoBehaviour
{

    private int nbTarget = 3;
    private int nbCurrentTargetActivate = 0;
    public Animation tube, coffre;
    public bool needInstanceBall = false;
    public ScenePatriManager spm;

    public void Start()
    {
        spm = FindObjectOfType<ScenePatriManager>();
        spm.LoadLevelInfo();
    }

    public int getNbTarget()
    {
        return nbTarget;
    }

    public void increaseTargetActivate()
    {
        nbCurrentTargetActivate++;
    }

    public int getNbTargetActivate()
    {
        return nbCurrentTargetActivate;
    }

    public Animation getTube()
    {
        return tube;
    }

    public Animation getCoffre()
    {
        return coffre;
    }
}