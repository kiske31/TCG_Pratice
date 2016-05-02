using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeckManager : MonoBehaviour {

    bool strat = false;
    public CardPrefab testCard;
    Dictionary<int, Card> choaDeck = new Dictionary<int, Card>(); // 초아의 덱
    Dictionary<int, Card> uhmDeck = new Dictionary<int, Card>(); // 엄갓의 덱
    List<int> choaHand = new List<int>(); // 초아의 손패
    List<int> uhmHand = new List<int>(); // 엄갓의 손패
    List<int> graveyard = new List<int>(); // 무덤 리스트

    // Use this for initialization
    void Awake ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            TestCard();
        }
        if (Input.GetKeyDown(KeyCode.A)) // 디버그로 카드가 잘 섞였는지 확인
        {
            StartDeckSetting(choaDeck);
            StartDeckSetting(uhmDeck);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {

            testCard.PrefabSetting(choaDeck[0].id);

            // for (int i = 0; i < 30; i++)
            // {
            //     Debug.Log(choaDeck[i].name);
            // }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            testCard.PrefabSetting(uhmDeck[0].id);

            // for (int i = 0; i < 30; i++)
            // {
            //     Debug.Log(uhmDeck[i].name);
            // }
        }
    }
    

    void StartDeckSetting(Dictionary<int, Card> Deck) // 36장의 카드중 랜덤으로 카드를 1장씩 얻어 랜덤 셔플된 30장의 덱을 구성한다.
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
        int randNum = Random.Range(0, 30);
        if (!strat)
        {
            StartDeckSetting(choaDeck);
            strat = true;
        }
        testCard.PrefabSetting(choaDeck[randNum].id);
    }
}
