using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ButtonPressRecognition : VRTK_InteractableObject {
    
    public override void StartUsing(VRTK_InteractUse currentUsingObject = null)
    {
        base.StartUsing(currentUsingObject);
        gameObject.transform.parent.gameObject.GetComponent<SpeechRecognitionEnginePerso>().startRecognition();
        gameObject.GetComponent<AudioSource>().Play();
    }
}
