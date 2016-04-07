using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SaveDataManager : MonoBehaviour
{
    private string playerWinCount = "PLAYER_WIN"; // 플레이어 총 승수 
    private string enemyWinCount = "ENEMY_WIN";   // 에너미 총 승수
    private string destroyCardCount = "DESTROY_CARD"; // 양 플레이어의 총 파괴된 카드수 (무덤에 놓일 때 카운트)
    private string drawCardCount = "DRAW_CARD"; // 플레이어가 뽑은 카드 수
    private string totalDamageCount = "TOTAL_DAMAGE_COUNT"; // 플레이어가 적에게 입힌 총 데미지

    private static SaveDataManager instance;

    Dictionary<int, string> HashKeyList = new Dictionary<int,string>();

    public static SaveDataManager Instance
    {
        get
        {
          if (instance == null)
           {
                instance = new SaveDataManager();
           }
        return instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        Init();
    }

    void Init()
    {
        int keyNum = 0;

        HashKeyList.Add(keyNum, playerWinCount);
        keyNum++;

        HashKeyList.Add(keyNum, enemyWinCount);
        keyNum++;

        HashKeyList.Add(keyNum, destroyCardCount);
        keyNum++;

        HashKeyList.Add(keyNum, drawCardCount);
        keyNum++;

        HashKeyList.Add(keyNum, totalDamageCount);
        keyNum++;

        for (int i = 0; i < keyNum; i++)
        {
            string temp;
            HashKeyList.TryGetValue(i, out temp);

            if (!PlayerPrefs.HasKey(temp))
            {
                SaveData(temp, 0);
            }
        }
    }

    public void SaveData(string HashKey, int Value)
    {
        PlayerPrefs.SetInt(HashKey, Value);
    }

    public int LoadData(int i)
    {
        string temp;
        HashKeyList.TryGetValue(i, out temp);
        return PlayerPrefs.GetInt(temp);
    }
}
