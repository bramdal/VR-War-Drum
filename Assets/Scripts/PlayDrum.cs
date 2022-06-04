using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDrum : MonoBehaviour
{
    AudioSource drumAudio;
    bool inputMutex = false;
    
    public DrumType thisDrumType;

    GameObject gameMaster;
    DrumInputManager drumInputManager;

    float timeTracker = 0f;

    void Start(){
        gameMaster = GameObject.FindWithTag("GameMaster");
        drumInputManager = gameMaster.GetComponent<DrumInputManager>();
        drumAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update(){
        if(inputMutex){
            timeTracker += Time.deltaTime;
            if(timeTracker >= 0.2f){
                inputMutex = false;
                timeTracker = 0f;
            }
        }
    }

    
    private void OnCollisionExit(Collision other){
        if(!inputMutex){
            inputMutex = true;
            drumAudio.volume = other.relativeVelocity.magnitude;
            drumAudio.Play();   
            FillDrumInput();
        }    
    }

    public void FillDrumInput(){
        drumInputManager.fillDrumInput(this.thisDrumType);
    }

    
    
}
