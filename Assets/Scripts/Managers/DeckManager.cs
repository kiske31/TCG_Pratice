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

    public GameObject[] card;

    public GameObject prefab;

    void Awake ()
    {
        StartDeckSetting(choaDeck);
        StartDeckSetting(uhmDeck);
        
       for (int i = 0; i < 36; i++)
       {
           card[i] = (GameObject)Instantiate(prefab, Vector3.zero, Quaternion.identity);
           card[i].name = "Card_" + i;
           card[i].transform.parent = this.gameObject.transform;
           card[i].SetActive(false);
           CardPrefab cardPrefab = card[i].GetComponent<CardPrefab>();
       
           if (i < 18)
           {
               cardPrefab.PrefabSetting(choaDeck[i].id);
               choaHand.Add(cardPrefab);
           }
           else
           {
               cardPrefab.PrefabSetting(uhmDeck[i - 18].id);
               choaHand.Add(cardPrefab);
           }
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
        if (num > 0)
        {
            card[num - 1].SetActive(false);
        }
        card[num].SetActive(true);
        num++;
        if (num > 35)
        {
            card[35].SetActive(false);
            num = 0;
        }
    }
}
