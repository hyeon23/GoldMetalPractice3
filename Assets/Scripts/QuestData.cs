using System.Collections;
using System.Collections.Generic;

public class QuestData//Monobehaivor�� ������ UnityEngine�� ��ӹ޴� �͵� �ʿ� X
{
    public string questName;
    public int[] npcId;
    
    public QuestData(string name, int[] npc)//������ ����
    {
        questName = name;
        npcId = npc;
    }
}
