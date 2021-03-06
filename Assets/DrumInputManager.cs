using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumInputManager : MonoBehaviour
{
    MetronomeSimple metronome;

    //int[] drumInputArray = {0,0,0,0};
    public DrumType[] drumInputArray = new DrumType[4];

    public CommandList commandList;
    
    //audio clips for reaction
    [SerializeField]
    AudioSource[] hitReactionAudioArray = new AudioSource[5];
    [SerializeField]
    GameObject AudioCollection;
    void Start()
    {
        metronome = GetComponent<MetronomeSimple>();
        hitReactionAudioArray = AudioCollection.GetComponents<AudioSource>();

    }

    public bool fillDrumInput(DrumType drumType){
        if(metronome.timingWindowEnabled){
            for(int i = 0; i < drumInputArray.Length; i++)
                if (drumInputArray[i] == DrumType.Empty)
                    drumInputArray[i] = drumType;

            if(drumInputArray[drumInputArray.Length - 1] != DrumType.Empty){
                //Notify command digestor here
                ExecuteCommand();
                cleanInputArray();
            }
            PlayAudioReaction(metronome.getInputQuality());
            return true;
        }    
        cleanInputArray();
        return false;
    }

    void cleanInputArray(){
        for(int i = 0; i < drumInputArray.Length; i++)
            drumInputArray[i] = DrumType.Empty;
    }
    
    void PlayAudioReaction(InputQualityCategory c){
        if(c != InputQualityCategory.Invalid)
            hitReactionAudioArray[(int)c + 2].Play();
    }

    void ExecuteCommand(){
        
        CommandList.Command thisCommand;
        thisCommand = SearchCommands();
        Debug.Log(thisCommand.name);
        //get reference of actor(s)
        //get actor(s) to execute
    }

    CommandList.Command SearchCommands(){
        int validity = 0;
        foreach (var command in commandList.commands){
            for(int i = 0; i < drumInputArray.Length; i++){
                if(drumInputArray[i] == command.inputs[i])
                    validity++;
                else{
                    validity = 0;
                    break;
                }
                if (validity == 4){
                    return command;
                }    
            }
        }
        CommandList.Command invalidCommand = new CommandList.Command();
        invalidCommand.name = "invalid command";
        return invalidCommand;
    }
        
}

