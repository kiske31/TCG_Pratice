using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeckManager : MonoBehaviour
{
    int num = 0;

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

    void Awake ()
    {
        StartDeckSetting(choaDeck);
        StartDeckSetting(uhmDeck);

        for (int i = 0; i < 10; i++)
        {
            choaHandCard[i] = (GameObject)Instantiate(prefab, Vector3.zero, Quaternion.identity);
            choaHandCard[i].name = "ChoaHandCard_" + i;
            choaHandCard[i].transform.parent = choaHandObj.transform;
            choaHandCard[i].SetActive(false);

            CardPrefab cardPrefab = choaHandCard[i].GetComponent<CardPrefab>();
            choaHand.Add(cardPrefab);
        }

        for (int i = 0; i < 10; i++)
        {
            uhmHandCard[i] = (GameObject)Instantiate(prefab, Vector3.zero, Quaternion.identity);
            uhmHandCard[i].name = "UhmHandCard_" + i;
            uhmHandCard[i].transform.parent = uhmHandObj.transform;
            uhmHandCard[i].SetActive(false);

            CardPrefab cardPrefab = uhmHandCard[i].GetComponent<CardPrefab>();
            uhmHand.Add(cardPrefab);
        }
        
        for (int i = 0; i < 7; i++)
        {
            choaFieldCard[i] = (GameObject)Instantiate(prefab, Vector3.zero, Quaternion.identity);
            choaFieldCard[i].name = "ChoaFieldCard_" + i;
            choaFieldCard[i].transform.parent = choaFieldObj.transform;
            choaFieldCard[i].SetActive(false);

            CardPrefab cardPrefab = choaFieldCard[i].GetComponent<CardPrefab>();
            choaField.Add(cardPrefab);
        }

        for (int i = 0; i < 7; i++)
        {
            uhmFieldCard[i] = (GameObject)Instantiate(prefab, Vector3.zero, Quaternion.identity);
            uhmFieldCard[i].name = "UhmFieldCard_" + i;
            uhmFieldCard[i].transform.parent = uhmFieldObj.transform;
            uhmFieldCard[i].SetActive(false);

            CardPrefab cardPrefab = uhmFieldCard[i].GetComponent<CardPrefab>();
            uhmField.Add(cardPrefab);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {

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

    public void TestCard()
    {
        for (int i = 0; i < 10; i++)
        {
            choaHandCard[i].SetActive(true);
            choaHandCard[i].transform.position = new Vector3(7.5f - (1.7f * i), 0, 2.5f);
            choaHand[i].PrefabSetting(choaDeck[i].id);
        }

        for (int i = 0; i < 10; i++)
        {
            uhmHandCard[i].SetActive(true);
            uhmHandCard[i].transform.position = new Vector3(8.0f - i, 0.2f, -5.5f);
            uhmHandCard[i].transform.rotation = Quaternion.Euler(0, 0, 180);
            uhmHand[i].PrefabSetting(uhmDeck[i].id);
        }
    }

    public void sad()
    {

    }
}
