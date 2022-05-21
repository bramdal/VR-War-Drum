using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetronomeSimple : MonoBehaviour
{
    [Header("Gameplay Variables")]
    [SerializeField]  
    int bpm;

    float secondsToBeat;
  
    float dspTime;
    float secondsToNextBeat;

    [SerializeField]
    float timingWindowSize;

    float timingWindowStart;
    float timingWindowEnd;
    public bool timingWindowEnabled;

    AudioSource metronomeBeatAudio;

    enum inputQualityCategory{
        VeryEarly = -2, Early = -1, Perfect = 0, Late = 1, VeryLate = 2 
    }

    private void Start() {
      dspTime = (float)AudioSettings.dspTime;
      //secondsToBeat = 60 / bpm;
      secondsToNextBeat = dspTime + (60f / bpm);

      metronomeBeatAudio = GetComponent<AudioSource>();
    }

    private void Update() {
        if(dspTime > secondsToNextBeat){
            secondsToNextBeat = (float)AudioSettings.dspTime + (60f / bpm);
            timingWindowStart = secondsToNextBeat - (timingWindowSize/2);

            //Audio stuff goes here
            //Debug.Log("Tick");
            metronomeBeatAudio.Play(); 
        } 

        if(dspTime > timingWindowStart)
            timingWindowEnabled = true;

        if (dspTime > timingWindowEnd){
            timingWindowEnabled = false;
            timingWindowEnd = secondsToNextBeat + (timingWindowSize/2);
        }

        dspTime += (float)AudioSettings.dspTime - dspTime;
    }

    public int getInputQuality(){
        float inputQuality = secondsToNextBeat - dspTime;
        if(inputQuality >= -0.1 && inputQuality <= 0.1)
            return (int)inputQualityCategory.Perfect;
        else if(inputQuality >= -0.2 && inputQuality < -0.1)
            return (int)inputQualityCategory.Early;  
        else if(inputQuality >= -0.3 && inputQuality < -0.2)
            return (int)inputQualityCategory.VeryEarly;  
        else if(inputQuality > 0.1 && inputQuality <= 0.2)
            return (int)inputQualityCategory.Late;
        else if(inputQuality > 0.2 && inputQuality <= 0.3)
            return (int)inputQualityCategory.VeryLate; 
        else
            return 99;            
        
    }
  

}
