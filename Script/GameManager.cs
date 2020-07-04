using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public talkManager talkManager;
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;
    public Image portraitImg;
    public QuestManager questManager;

    private void Start()
    {
        talkPanel.SetActive(false);
    }
    // Update is called once per frame
    public void Action(GameObject scanObj)
    {
        
        
        scanObject = scanObj;
        objData ObjData = scanObject.GetComponent<objData>();
        Talk(ObjData.id, ObjData.isNpc);
        
        talkPanel.SetActive(isAction);

    }

    void Talk(int id, bool isNpc)
    {
        //Set Talk Data
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id+questTalkIndex, talkIndex);
        Debug.Log(talkData);
        //End Talk
        if (talkData==null)
        {
            isAction = false;
            talkIndex = 0;
            //Debug.Log(questManager.CheckQuest(id));
            return;
        }
        else
        {
            Debug.Log("not null");
        }
        
        if (isNpc)
        {
            talkText.text = talkData.Split('|')[0];

            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split('|')[1]));
            portraitImg.color = new Color(1, 1, 1, 1);
        }
        else
        {
            talkText.text = talkData;

           
            portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }
}
