using UnityEngine;

public class QuestData
{
    public string _questName;
    public int[] _npcId;

    public QuestData(string name, int[] npcId)
    {
        _questName = name;
        _npcId = npcId;
    }
}
