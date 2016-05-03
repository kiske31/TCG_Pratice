using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeckManager : MonoBehaviour
{
    // 데이터로 존재하는 60 장의 카드가 딕셔너리에 담긴다. 프리펩은 필요 없다.
    Dictionary<int, Card> choaDeck = new Dictionary<int, Card>(); // 초아의 덱 (max 30)
    Dictionary<int, Card> uhmDeck = new Dictionary<int, Card>(); // 엄갓의 덱 (max 30)

    // 최대 34장의 프리펩이 필요
    List<CardPrefab> choaHand = new List<CardPrefab>(); // 초아의 손패 (max 10)
    List<CardPrefab> uhmHand = new List<CardPrefab>(); // 엄갓의 손패 (max 10)
    List<CardPrefab> choaField = new List<CardPrefab>(); // 초아의 필드 (max 7)
    List<CardPrefab> uhmField = new List<CardPrefab>(); // 엄갓의 필드 (max 7)

    // 카드 아이디 값만 저장하는 데이터 리스트 프리펩은 필요 없다.
    List<int> graveyard = new List<int>(); // 무덤 리스트 (max infinity)
    
    public GameObject[] choaHandCard; // 카드 오브젝트 배열들
    public GameObject[] choaFieldCard;
    public GameObject[] uhmHandCard;
    public GameObject[] uhmFieldCard;

    public GameObject prefab; // 기본 카드 프리펩

    public GameObject choaFieldObj; // 카드들의 Root가 될 빈 게임 오브젝트 
    public GameObject uhmFieldObj; 
    public GameObject choaHandObj; 
    public GameObject uhmHandObj;

    int mulligunCount = 0; // 멀리건 카운트
    public int choaHadnCount = 0;
    public int uhmHadnCount = 0;

    void Awake ()
    {
        StartDeckSetting(choaDeck);
        StartDeckSetting(uhmDeck);

        InitCard(choaHandCard, choaHand, "ChoaHandCard_", choaHandObj);
        InitCard(uhmHandCard, uhmHand, "UhmHandCard_", uhmHandObj);
        InitCard(choaFieldCard, choaField, "ChoaFieldCard_", choaFieldObj);
        InitCard(uhmFieldCard, uhmField, "UhmFieldCard_", uhmFieldObj);                                                                     
    }

    // 35장의 카드중 랜덤으로 카드를 1장씩 얻어 랜덤 셔플된 30장의 덱을 구성한다.
    void StartDeckSetting(Dictionary<int, Card> Deck) 
    {
        for (int i = 0; i < 30; i++) 
        {
            while (true)
            {
                int num = Random.Range(0, 36);

                if (!Deck.ContainsValue(CardManager.Instance.CardList[num]))
                {
                    Deck.Add(i, CardManager.Instance.CardList[num]);
                    break;
                }
            }
        }
    }

    // cardObj = 카드 배열 prefabList = 카드 프리펩 리스트, name = 할당될 오브젝트 네임, parentObj = 부모로 삼게 될 루트 오브젝트
    public void InitCard(GameObject[] cardObj, List<CardPrefab> prefabList, string name, GameObject parentObj)
    {
        for (int i = 0; i < cardObj.Length; i++)
        {
            cardObj[i] = (GameObject)Instantiate(prefab, Vector3.zero, Quaternion.identity);
            cardObj[i].name = name + i;
            cardObj[i].transform.parent = parentObj.transform;
            cardObj[i].SetActive(false);

            CardPrefab cardPrefab = cardObj[i].GetComponent<CardPrefab>();
            prefabList.Add(cardPrefab);
        }
    }

    // 멀리건용 카드 세팅
    public void StartMulligun()
    {
        int posX = 4;
        int num = Random.Range(0, 2);
       
        if (num == 0)
        {
            choaHadnCount = 3;
            uhmHadnCount = 4;
        }
        else
        {
            choaHadnCount = 4;
            uhmHadnCount = 3;
            posX = 6;
        }

        for (int i = 0; i < choaHadnCount; i++)
        {
            choaHandCard[i].SetActive(true);
            choaHandCard[i].transform.position = new Vector3(posX - (4 * i), 0, -1);
            choaHand[i].PrefabSetting(choaDeck[i].id);
            choaHand[i].DeckManagerLink(this);
            choaHand[i].state = CardState.Mulligun;
        }

        for (int i = 0; i < uhmHadnCount; i++)
        {
            uhmHandCard[i].SetActive(true);
            uhmHandCard[i].transform.position = new Vector3(8.0f - i, 0.2f, -5.5f);
            uhmHandCard[i].transform.rotation = Quaternion.Euler(0, 0, 180);
            uhmHand[i].PrefabSetting(uhmDeck[i].id);
            uhmHand[i].DeckManagerLink(this);
        }
    }

    // 멀리건이 끝난 뒤 카드를 교환해줌
    void cardExchange()
    {
        for (int i = 0; i < choaHadnCount; i++)
        {
            if (choaHand[i].state == CardState.Change)
            {
                int changeNum = 29 - i;
                Card changeCard;
                Card tempCard;

                choaDeck.TryGetValue(i, out tempCard);
                choaDeck.TryGetValue(changeNum, out changeCard);

                choaDeck.Remove(i);
                choaDeck.Remove(changeNum);

                choaHand[i].PrefabSetting(changeCard.id);

                choaDeck.Add(i, changeCard);
                choaDeck.Add(changeNum, tempCard);
            }
        }

        if (choaHadnCount == 4)
        {
            choaHandCard[4].SetActive(true);
            choaHandCard[4].transform.position = new Vector3(6 - (4 * 4), 0, -1);
            choaHand[4].PrefabSetting(37);
            choaHand[4].DeckManagerLink(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartMulligun();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cardExchange();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {

        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {

        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {

        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {

        }
    }

    public void TestCard()
    {

    }
}
