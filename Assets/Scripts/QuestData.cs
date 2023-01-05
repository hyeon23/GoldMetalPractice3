using System.Collections;
using System.Collections.Generic;

public class QuestData//Monobehaivor를 지워서 UnityEngine을 상속받는 것도 필요 X
{
    public string questName;
    public int[] npcId;
    
    public QuestData(string name, int[] npc)//생성자 선언
    {
        questName = name;
        npcId = npc;
    }
}
