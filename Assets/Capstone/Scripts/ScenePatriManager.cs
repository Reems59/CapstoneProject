using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenePatriManager : GenericSingletonClass<ScenePatriManager>{

    private List<Mot> listMots;
    private Mot motchoisi;
    private int nbVoyelles;
    private int nbConsonnes;
    public GameObject menuCode;
    public GameObject letterC, letterV;


    public override void Awake()
    {
        base.Awake();
        menuCode.transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<Text>().text = "Number of vowels find : " + nbVoyelles;
        menuCode.transform.GetChild(0).transform.GetChild(2).gameObject.GetComponent<Text>().text = "Number of consonants find : " + nbConsonnes;
        iniListMots(menuCode.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject);
    }

    public void iniListMots(GameObject code)
    {
        Mot m1 = new Mot();
        m1.motComplet = "Regin";
        Tuple t1 = code.transform.GetChild(0).gameObject.AddComponent<Tuple>();
        t1.key = "C";
        t1.value = "R";
        Tuple t2 = code.transform.GetChild(1).gameObject.AddComponent<Tuple>();
        t2.key = "V";
        t2.value = "e";
        Tuple t3 = code.transform.GetChild(2).gameObject.AddComponent<Tuple>();
        t3.key = "C";
        t3.value = "g";
        Tuple t4 = code.transform.GetChild(3).gameObject.AddComponent<Tuple>();
        t4.key = "V";
        t4.value = "i";
        Tuple t5 = code.transform.GetChild(4).gameObject.AddComponent<Tuple>();
        t5.key = "C";
        t5.value = "n";
        m1.t1 = new Tuple[2] { t1, t2 };
        m1.t2 = new Tuple[2] { t3, t4 };
        m1.t3 = new Tuple[1] { t5 };
        motchoisi = m1;



    }
    public void LoadLevelInfo()
    {
        Scene scene = SceneManager.GetActiveScene();
        GameObject UIMap = GameObject.Find("CanvasMapUI");
        GameObject rewards = GameObject.Find("Rewards");
        if (scene.name == "scene1")
        {
            FillLetersOnRewards(motchoisi.t1, rewards, scene);
        }
        else if(scene.name == "scene2")
        {
            FillLetersOnRewards(motchoisi.t2, rewards, scene);
        }
        else
        {
            FillLetersOnRewards(motchoisi.t3, rewards, scene);
        }
        LoadMapUiData(UIMap);
    }

    public void FillLetersOnRewards(Tuple[] t, GameObject rewards, Scene scene)
    {
        if (!t[0].isNull())
        {
            if (t[0].GetKey() == "C")
            {
                //Debug.Log("C0");
                GameObject gC = Instantiate(letterC);
                gC.transform.parent = rewards.transform.GetChild(0);
                gC.transform.GetChild(0).rotation = Quaternion.identity;
                gC.transform.localScale = Vector3.one;
                gC.transform.GetChild(0).gameObject.GetComponent<LetterScript>().setLetterGameObject(t[0].gameObject);
            }
            else if (t[0].GetKey() == "V")
            {
                GameObject gC = Instantiate(letterV);
                gC.transform.GetChild(0).rotation = Quaternion.identity;
                gC.transform.localScale = Vector3.one;
                gC.transform.parent = rewards.transform.GetChild(0);
                gC.transform.GetChild(0).gameObject.GetComponent<LetterScript>().setLetterGameObject(t[0].gameObject);
            }
        }
        if(t.Length > 1)
        {
            if (!t[1].isNull())
            {
                if (t[1].GetKey() == "C")
                {
                    GameObject gC = Instantiate(letterC);
                    gC.transform.parent = rewards.transform.GetChild(1);
                    gC.transform.GetChild(0).rotation = Quaternion.identity;
                    gC.transform.localScale = Vector3.one;
                    gC.transform.GetChild(0).gameObject.GetComponent<LetterScript>().setLetterGameObject(t[1].gameObject);
                }
                else if (t[1].GetKey() == "V")
                {
                    GameObject gC = Instantiate(letterV);
                    gC.transform.parent = rewards.transform.GetChild(1);
                    gC.transform.GetChild(0).rotation = Quaternion.identity;
                    gC.transform.localScale = Vector3.one;
                    gC.transform.GetChild(0).gameObject.GetComponent<LetterScript>().setLetterGameObject(t[1].gameObject);
                }
            }
        }
       
    }
    
    public void IncreaseNbConsonnes()
    {
        nbConsonnes++;
        menuCode.transform.GetChild(0).transform.GetChild(2).gameObject.GetComponent<Text>().text = "Number of consonants find : " + nbConsonnes;
    }

    public void IncreaseNbVoyelles()
    {
        nbVoyelles++;
        menuCode.transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<Text>().text = "Number of vowels find : " + nbVoyelles;

    }

    public void LoadMapUiData(GameObject map)
    {
        LoadRoomMap(motchoisi.t1, map, 0);
        LoadRoomMap(motchoisi.t2, map, 1);
        LoadRoomMap(motchoisi.t3, map, 2);

    }

    public void LoadRoomMap(Tuple[] t, GameObject map, int indexRoom)
    {
        int nbC = 0, nbV = 0;
        int index = 0;
        if (!t[index].isNull())
        {
            if (t[index].key == "V")
            {
                nbV++;
                map.transform.GetChild(indexRoom).transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + nbV;

            }
            else
            {
                nbC++;
                map.transform.GetChild(indexRoom).transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + nbC;
            }
        }
        index++;
        if (t.Length > 1)
        {
            if (!t[index].isNull())
            {
                if (t[index].key == "V")
                {
                    nbV++;
                    map.transform.GetChild(indexRoom).transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + nbV;

                }
                else
                {
                    nbC++;
                    map.transform.GetChild(indexRoom).transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + nbC;
                }
            }
        }
    }

    public string getMotChoisi()
    {
        return motchoisi.motComplet;
    }
}

