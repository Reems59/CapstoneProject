using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tuple : MonoBehaviour {

    public string key;
    public string value;
    private bool noValue = false;
    private bool found = false;

    public string GetKey()
    {
        return key;
    }

    public string GetValue()
    {
        return value;
    }

    public bool isNull()
    {
        return noValue;
    }

    public void setNullTuple()
    {
        noValue = true;
    }
    public bool isFound()
    {
        return found;
    }

    public void justfound()
    {
        gameObject.GetComponent<Text>().text = value;
        found = true;
        noValue = true;
        ScenePatriManager spm = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.GetComponent<ScenePatriManager>();
        if(key == "C")
        {
            spm.IncreaseNbConsonnes();
        }else
        {
            spm.IncreaseNbVoyelles();
        }
    }

}
