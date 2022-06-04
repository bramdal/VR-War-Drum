using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gameplay Commands", menuName = "Gameplay Commands", order = 1)]
public class CommandList : ScriptableObject
{
    [System.Serializable] 
    public class Command{
       public string name;
       public DrumType[] inputs = new DrumType[4];
    }

    
    public List<Command> commands = new List<Command>();
}
