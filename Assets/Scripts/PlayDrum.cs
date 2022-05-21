using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDrum : MonoBehaviour
{
    AudioSource drumAudio;
    // Start is called before the first frame update
    public enum DrumType{
        Top = 1, Left = 2, Bottom = 3, Right = 4
    }
    
    public DrumType thisDrumType;

    GameObject gameMaster;
    DrumInputManager drumInputManager;

    void Start(){
        gameMaster = GameObject.FindWithTag("GameMaster");
        drumInputManager = gameMaster.GetComponent<DrumInputManager>();
        drumAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update(){
        //Debug.Log(drumInputManager.name);
    }

    private void OnCollisionEnter(Collision other) {
        drumAudio.volume = other.relativeVelocity.magnitude;
        drumAudio.Play();    
    }
    
}
