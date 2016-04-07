using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Card
{
    public int id;      // 카드 고유 번호 이것으로 카드를 찾음
    public string prefabPath; // 카드 이미지 경로
    public string name; // 카드 이름
    public string description; // 카드 설명
    public int mana; // 카드 마나 코스트
    public bool monster; //  몬스터 카드 인가?

    // 몬스터 카드라면 값이 들어감. 아니면 0
    public int attack; // 카드의 공격력
    public int hp; // 카드의 에너지
}

public class CardManager : MonoBehaviour 
{
    public Dictionary<int, Card> CardList = new Dictionary<int, Card>();

    private static CardManager instance; 

    public static CardManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CardManager();
            }
            return instance;
        }
    }

    public void GetCard()
    { 
    
    }
}
