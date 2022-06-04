using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetronomeSimple : MonoBehaviour
{
    [Header("Gameplay Variables")]
    [SerializeField]  
    public int bpm;

    float secondsToBeat;
  
    float dspTime;
    float secondsToNextBeat;
    float lastBeatTime;

    [SerializeField]
    float timingWindowSize;

    float timingWindowStart;
    float timingWindowEnd;

    [Header("Visual Indicator for Timing Window")]
    public bool timingWindowEnabled;

    AudioSource metronomeBeatAudio;

    private void Start() {
      dspTime = (float)AudioSettings.dspTime;
      secondsToNextBeat = dspTime + (60f / bpm);
      metronomeBeatAudio = GetComponent<AudioSource>();
    }  

    private void Update() {
        if(dspTime > secondsToNextBeat){
            lastBeatTime = secondsToNextBeat;
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

    public InputQualityCategory getInputQuality(){
       if(timingWindowEnd > timingWindowStart){
            if(secondsToNextBeat - dspTime <= 0.25f * timingWindowSize)
                return InputQualityCategory.Perfect;
               
            if(secondsToNextBeat - dspTime <= 0.4f * timingWindowSize)
                return InputQualityCategory.Late;
                
            
            if(secondsToNextBeat - dspTime <= 0.5f * timingWindowSize)
                return InputQualityCategory.VeryLate;    
       }
       else{

            if(timingWindowEnd - dspTime <= 0.25f * timingWindowSize)
                return InputQualityCategory.Perfect;    
            
    
            if(timingWindowEnd - dspTime <= 0.4f * timingWindowSize)
                return InputQualityCategory.Early;
  
            if(timingWindowEnd - dspTime <= 0.5f * timingWindowSize)
                return InputQualityCategory.VeryEarly;
       }

       return InputQualityCategory.Invalid;

    }  

}
