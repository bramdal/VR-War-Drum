using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumInputManager : MonoBehaviour
{
    MetronomeSimple metronome;

    int[] drumInputArray = {0,0,0,0};
    // Start is called before the first frame update
    void Start()
    {
        metronome = GetComponent<MetronomeSimple>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool fillDrumInput(int drumType){
        if(metronome.timingWindowEnabled){

            for(int i = 0; i < drumInputArray.Length; i++)
                if (drumInputArray[i] == 0)
                    drumInputArray[i] = drumType;

            if(drumInputArray[drumInputArray.Length - 1] != 0 ){
                //Notify command digestor here
                cleanInputArray();
            }
            int c = metronome.getInputQuality();
            // switch(c){
            //     case -2:
            //         //logic
            //         break;
            //     case -1:
            //         //logic
            //         break;
            //     case 0:
            //         //logic
            //         break;
            //     case 1:
            //         //logic
            //         break;
            //     case 2:
            //         //logic
            //         break;
            //     default:
            //         //logic
            //         break;
            // }
            
            return true;
        }    
        cleanInputArray();
        return false;
    }

    void cleanInputArray(){
        for(int i = 0; i < drumInputArray.Length; i++)
            drumInputArray[i] = 0;
    }
    
}
