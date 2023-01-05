using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect: MonoBehaviour
{
    
    public GameObject cursor;
    public int cps; // Char Per Seconds
    public bool isAnimation;

    Text msgText;
    AudioSource audiosource;

    int index;
    string targetMsg;
    float interval;
    

    private void Awake()
    {
        msgText = GetComponent<Text>();
        audiosource = GetComponent<AudioSource>();
    }


    public void SetMsg(string msg)
    {
        if (isAnimation)
        {
            CancelInvoke();
            msgText.text = targetMsg;
            EffectEnd();    
        }
        else
        {
            targetMsg = msg;
            EffectStart();
        }
    }

    void EffectStart()
    {
        msgText.text = "";
        index = 0;
        cursor.SetActive(false);
        interval = 1.0f / cps;
        isAnimation = true;
        Invoke("Effecting", interval);
    }
    void Effecting()
    {
        if(msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }
        msgText.text += targetMsg[index];
        if(targetMsg[index] != ' ' || targetMsg[index] != '.')
            audiosource.Play();
        index++;

        //Recursive
        Invoke("Effecting", interval);
        
    }
    void EffectEnd()
    {
        isAnimation = false;
        cursor.SetActive(true);
    }
}
