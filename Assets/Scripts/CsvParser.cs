using UnityEngine;
using System.IO;
using System.Collections;




public class CsvParser : MonoBehaviour 
{
    TextAsset dataText;
    string filePath = "CardDataTable";
    string[] stringList;
    
    void Awake()
    {
        CsvParsing();
    }

    void CsvParsing()
    {
        dataText = Resources.Load("CardData/" + filePath) as TextAsset;
        stringList = dataText.text.Split('\n');
        CardDataSetting();
    }

    void CardDataSetting()
    {
        for (int i = 1; i < stringList.Length - 1; i++)
        {
            string[] dataList;
            dataList = stringList[i].Split(',');
            Card temp = new Card();
            temp.id = int.Parse(dataList[0]); // 카드 유아이디 
            temp.prefabPath = dataList[1]; // 카드 이미지 프리펩 경로
            temp.name = dataList[2]; // 카드 이름
            temp.description = dataList[3]; // 카드 설명
            temp.mana = int.Parse(dataList[4]); // 카드 마나
            temp.type = int.Parse(dataList[5]); // 카드 타입 
            temp.ability = int.Parse(dataList[6]); // 카드 특능 수치
            temp.attack = int.Parse(dataList[7]); // 카드 공격력
            temp.hp = int.Parse(dataList[8]); //  카드 체력
            temp.legendary = bool.Parse(dataList[9]); // 오우 전설 카드~~
            CardManager.Instance.CardList.Add(temp.id, temp);
        }
    }
}
