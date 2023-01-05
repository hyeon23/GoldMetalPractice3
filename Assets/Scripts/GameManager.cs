using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isAction;
    public int talkIndex;
    public TalkManager talkManager;
    public QuestManager questManager;

    public Animator talkPanel;
    public Animator portraitAnime;
    public GameObject menuSet;
    public GameObject scanObject;
    public Text questText;
    public TypeEffect talk;
    public Image portraitImg;
    public Sprite prevPortrait;
    public GameObject player;

    private void Start()
    {
        GameLoad();
        questText.text = questManager.CheckQuest();
    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);
        talkPanel.SetBool("isShow", isAction);
        Debug.Log(gameObject.name);
    }

    private void Update()
    {
        

        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
                menuSet.SetActive(false);
            else
                menuSet.SetActive(true);
        }       
    }

    void Talk(int id, bool isNpc)
    {
        int questTalkIndex = 0;
        string talkData = "";
        if (talk.isAnimation)
        {
            talk.SetMsg("");
            return;
        }  
        else
        {
            questTalkIndex = questManager.GetQuestTalkIndex(id);
            talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        }

        //End Talk
        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            questText.text = questManager.CheckQuest(id);
            return;
        }

        if (isNpc)
        {
            talk.SetMsg(talkData.Split(':')[0]);

            //Show Portrait
            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));//int.Parse()를 통해 형변환
            portraitImg.color = new Color(1, 1, 1, 1);//투명도로 보이기 조절

            //Animation Portrait
            if (prevPortrait != portraitImg.sprite)
            {
                portraitAnime.SetTrigger("doEffect");
                prevPortrait = portraitImg.sprite;
            }

        }
        else
        {
            talk.SetMsg(talkData);
            portraitImg.color = new Color(1, 1, 1, 0);
        }
        isAction = true;
        talkIndex++;
    }

    public void GameSave()
    {
        //player.x player.y
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetInt("QuestId", questManager.questId);
        PlayerPrefs.SetInt("QuestActionIndex", questManager.questActionIndex);
        PlayerPrefs.Save();

        menuSet.SetActive(false);
    }

    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("PlayerX"))
            return;
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        int questId = PlayerPrefs.GetInt("QuestId");
        int questActionIndex = PlayerPrefs.GetInt("QuestActionIndex");

        player.transform.position = new Vector3(x, y, 0);
        questManager.questId = questId;
        questManager.questActionIndex = questActionIndex;
        questManager.ControlObject();
    }

    public void GameExit()//게임 종료 함수 만들기
    {
        Application.Quit();
    }
}
