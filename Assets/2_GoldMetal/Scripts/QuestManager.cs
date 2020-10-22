using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    public GameObject[] questObj;
    Dictionary<int, QuestData> _questDict;

    private void Awake()
    {
        _questDict = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        _questDict.Add(10, new QuestData("마을 사람들과 대화하기", new int[] { 1000, 2000 }));
        _questDict.Add(20, new QuestData("루도의 동전 찾아주기", new int[] { 5000, 2000 }));
        _questDict.Add(30, new QuestData("퀘스트 올 클리어!", new int[] { 0 }));
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        if(id == _questDict[questId]._npcId[questActionIndex])
            questActionIndex++;

        ControlObject();

        if (questActionIndex == _questDict[questId]._npcId.Length)
            NextQuest();

        return _questDict[questId]._questName;
    }

    public string CheckQuest()
    {
        return _questDict[questId]._questName;
    }

    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    void ControlObject()
    {
        switch (questId)
        {
            case 10:
                if (questActionIndex == 2)
                    questObj[0].SetActive(true);
                break;
            case 20:
                if (questActionIndex == 1)
                    questObj[0].SetActive(false);
                break;
        
        }
    }
}
