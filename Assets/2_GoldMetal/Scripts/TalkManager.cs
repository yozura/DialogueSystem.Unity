using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> _talkDict;
    Dictionary<int, Sprite> _portraitDict;

    public Sprite[] _portraitArr;

    private void Awake()
    {
        _talkDict = new Dictionary<int, string[]>();
        _portraitDict = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        _talkDict.Add(1000, new string[] { "안녕?:0", "이 곳에 처음 왔구나?:1" });
        _talkDict.Add(2000, new string[] { "여어:1", "이 곳 호수는 정말 아름답지?:0", "사실 이 호수에는 무언가 비밀이 있다고 해:2" });
        _talkDict.Add(100, new string[] { "나무로 된 평범한 상자다." });
        _talkDict.Add(101, new string[] { "누군가 사용한 흔적이 있는 책상이다." });
        _talkDict.Add(102, new string[] { "오래된 큰바위다." });

        _talkDict.Add(1000 + 10, new string[] { "어서 와:0", "이 마을에 놀라운 전설이 있다는데:1", "오른쪽 호수에 있는 루도가 알려줄꺼야.:2"  });
        _talkDict.Add(2000 + 11, new string[] { "여어:0", "이 호수의 전설에 들으러 온거야?:1", "그럼 일 좀 하나 해주면 좋을텐데...:2", "내 집 근처에 떨어진 동전 좀 주워줬으면 알려줄게:3" });
        _talkDict.Add(1000 + 20, new string[] { "루도의 동전?:0", "돈을 흘리고 다니면 못쓰지!:3", "나중에 루도에게 한마디 해야겠어.:3"});
        _talkDict.Add(2000 + 20, new string[] { "찾으면 꼭 좀 가져다 줘:1"});
        _talkDict.Add(5000 + 20, new string[] { "근처에서 동전을 찾았다." });
        _talkDict.Add(2000 + 21, new string[] { "엇! 찾아줘서 고마워!:2" });

        _portraitDict.Add(1000 + 0, _portraitArr[0]);
        _portraitDict.Add(1000 + 1, _portraitArr[1]);
        _portraitDict.Add(1000 + 2, _portraitArr[2]);
        _portraitDict.Add(1000 + 3, _portraitArr[3]);
        _portraitDict.Add(2000 + 0, _portraitArr[4]);
        _portraitDict.Add(2000 + 1, _portraitArr[5]);
        _portraitDict.Add(2000 + 2, _portraitArr[6]);
        _portraitDict.Add(2000 + 3, _portraitArr[7]);
    }

    public string GetTalk(int id, int talkIndex)
    {
        if(!_talkDict.ContainsKey(id))
        {
            if (!_talkDict.ContainsKey(id - id % 10))
                return GetTalk(id - id % 10, talkIndex);
            else
                return GetTalk(id - id % 100, talkIndex);
        }

        if (talkIndex == _talkDict[id].Length)
            return null;
        else
            return _talkDict[id][talkIndex];
    }
    
    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return _portraitDict[id + portraitIndex];
    }
}
