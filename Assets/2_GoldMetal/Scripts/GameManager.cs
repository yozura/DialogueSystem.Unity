using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager _talkMgr;
    public QuestManager _questMgr;
    public GameObject _talkPanel;
    public Image _talkPortrait;
    public Text _talkText;
    public GameObject _scanObj;
    public int _talkIndex;
    public bool isAction;

    private void Start()
    {
        Debug.Log(_questMgr.CheckQuest());
    }

    public void Action(GameObject go)
    {
        _scanObj = go;
        ObjectData objData = _scanObj.GetComponent<ObjectData>();
        Talk(objData, objData.isNPC);

        _talkPanel.SetActive(isAction);
    }

    void Talk(ObjectData data, bool isNpc)
    {
        int questTalkIndex = _questMgr.GetQuestTalkIndex(data.id);
        string tempTalk = _talkMgr.GetTalk(data.id + questTalkIndex, _talkIndex);
        if (tempTalk == null)
        {
            isAction = false;
            _talkIndex = 0;
            Debug.Log(_questMgr.CheckQuest(data.id));
            return;
        }

        if (isNpc)
        {
            _talkText.text = tempTalk.Split(':')[0];
            _talkPortrait.sprite = _talkMgr.GetPortrait(data.id, int.Parse(tempTalk.Split(':')[1]));
            _talkPortrait.color = new Color(1, 1, 1, 1);
        }
        else
        {
            _talkText.text = tempTalk;
            _talkPortrait.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        _talkIndex++;
    }
}
