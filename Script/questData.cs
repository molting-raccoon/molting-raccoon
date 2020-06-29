using System.Collections;
using System.Collections.Generic;


public class questData 
{
    public string questName;
    public int[] npcId;

    public questData(string str, int[] npc)
    {
        questName = str;
        npcId = npc;
    }
}
