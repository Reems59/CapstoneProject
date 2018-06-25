using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class SpeechRecognitionEnginePerso : MonoBehaviour
{
    private string[] keywords = new string[] { "blabla" };
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;
    protected PhraseRecognizer recognizer;
    protected string word = "right";
    private bool started = false;
    public GameObject finalPortal;

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
    }

    private void Update()
    {
        if(gameObject.activeSelf != true)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
            started = false;
        }
        else
        {
            if(word == keywords[0])
            {
                finalPortal.SetActive(true);
            }
        }
    }

    private void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
            started = false;
        }
    }

    public void startRecognition()
    {
        if (!started)
        {
            keywords[0] = gameObject.transform.parent.transform.parent.gameObject.GetComponent<ScenePatriManager>().getMotChoisi();
            if (keywords != null)
            {
                recognizer = new KeywordRecognizer(keywords, confidence);
                recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
                recognizer.Start();
                started = true;
            }
        }
        
    }
}
