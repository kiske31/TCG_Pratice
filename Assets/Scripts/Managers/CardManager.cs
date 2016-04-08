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
    public int type; // 몬스터의 타입 노멀, 도발, 죽메, 전함, 지속 능력
                     // 즉발 마법이냐 비밀이냐
                     // 몬스터 카드
                     // 0 == 노멀
                     // 1 == 도발
                     // 2 == 죽메
                     // 3 == 전함
                     // 4 == 지속 특능
                     // 5 == 돌진
                     // 마법 카드
                     // 6 == 즉발 마법
                     // 7 == 비밀

    public int ability; // 마법이나 몬스터의 특수능력의 양 : 데미지, 회복량, 카드 드로우 수 등등 default : 0
   
    // 몬스터 카드라면 값이 들어감. 아니면 default : 0
    public int attack; // 카드의 공격력
    public int hp; // 카드의 에너지
    public bool legendary; // 전설 카드인가?
}

public class CardManager : MonoBehaviour
{
    public Dictionary<int, Card> CardList = new Dictionary<int, Card>(); // 카드의 데이터들이 담긴 딕셔너리
    
    private static CardManager instance = null; 

    public static CardManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CardManager();
            }

            if (instance == null)
            {
                GameObject obj = new GameObject("CardManager");
                instance = obj.AddComponent(typeof(CardManager)) as CardManager;
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
