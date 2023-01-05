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
        talkData.Add(1000, new string[] { "안녕?:0", "이곳에 처음 왔구나?:1" });
        talkData.Add(2000, new string[] { "반가워:0", "이 호수가 정말 아름답지:1", "이 호수엔 전설이 있어...:2" });
        talkData.Add(3000, new string[] { "평범한 나무상자인듯 하다." });
        talkData.Add(4000, new string[] { "사용감이 있는 책상이다." });


        //Quest Talk
        talkData.Add(10 + 1000, new string[] { "어서 와!:0", "이 마을에 놀라운 전설이 있는데:1", "오른쪽 호수의 루도가 알려줄꺼야:2" });
        talkData.Add(11 + 2000, new string[] { "여어...:0", "이 호수의 전설을 들으로 온거야?:1", "내 집 근처의 동전을 주워줬으면 하는데...:2" });

        talkData.Add(20 + 1000, new string[] { "루도의 동전?:0", "돈을 흘리고 다니면 못쓰지!:1", "나중에 루도에게 한마디 해줘야겠어.:2", });
        talkData.Add(20 + 2000, new string[] { "찾으면 꼭 좀 가져다 줘.:0", });
        talkData.Add(20 + 5000, new string[] { "반짝거리는 동전이다. 루도의 동전인듯 하다.", });

        talkData.Add(21 + 1000, new string[] { "엇 내 동전이야!:0", "찾아줘서 고마워!:1", });

        portraitData.Add(1000 + 0, protraitArr[0]);
        portraitData.Add(1000 + 1, protraitArr[1]);
        portraitData.Add(1000 + 2, protraitArr[2]);
        portraitData.Add(1000 + 3, protraitArr[3]);

        portraitData.Add(2000 + 0, protraitArr[4]);
        portraitData.Add(2000 + 1, protraitArr[5]);
        portraitData.Add(2000 + 2, protraitArr[6]);
        portraitData.Add(2000 + 3, protraitArr[7]);
    }

    //GenerateData()를 통해 발생시킨 Talk를 가져오는 함수
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
