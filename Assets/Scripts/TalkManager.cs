using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;
    public Sprite[] protraitArr;
    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] { "�ȳ�?:0", "�̰��� ó�� �Ա���?:1" });
        talkData.Add(2000, new string[] { "�ݰ���:0", "�� ȣ���� ���� �Ƹ�����:1", "�� ȣ���� ������ �־�...:2" });
        talkData.Add(3000, new string[] { "����� ���������ε� �ϴ�." });
        talkData.Add(4000, new string[] { "��밨�� �ִ� å���̴�." });


        //Quest Talk
        talkData.Add(10 + 1000, new string[] { "� ��!:0", "�� ������ ���� ������ �ִµ�:1", "������ ȣ���� �絵�� �˷��ٲ���:2" });
        talkData.Add(11 + 2000, new string[] { "����...:0", "�� ȣ���� ������ ������ �°ž�?:1", "�� �� ��ó�� ������ �ֿ������� �ϴµ�...:2" });

        talkData.Add(20 + 1000, new string[] { "�絵�� ����?:0", "���� �긮�� �ٴϸ� ������!:1", "���߿� �絵���� �Ѹ��� ����߰ھ�.:2", });
        talkData.Add(20 + 2000, new string[] { "ã���� �� �� ������ ��.:0", });
        talkData.Add(20 + 5000, new string[] { "��¦�Ÿ��� �����̴�. �絵�� �����ε� �ϴ�.", });

        talkData.Add(21 + 1000, new string[] { "�� �� �����̾�!:0", "ã���༭ ����!:1", });

        portraitData.Add(1000 + 0, protraitArr[0]);
        portraitData.Add(1000 + 1, protraitArr[1]);
        portraitData.Add(1000 + 2, protraitArr[2]);
        portraitData.Add(1000 + 3, protraitArr[3]);

        portraitData.Add(2000 + 0, protraitArr[4]);
        portraitData.Add(2000 + 1, protraitArr[5]);
        portraitData.Add(2000 + 2, protraitArr[6]);
        portraitData.Add(2000 + 3, protraitArr[7]);
    }

    //GenerateData()�� ���� �߻���Ų Talk�� �������� �Լ�
    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex);//Get First Talk
            else
                return GetTalk(id - id % 10, talkIndex);//Get First Quest Talk
        }

        if(talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
