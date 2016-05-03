using UnityEngine;
using System.Collections;

public class CardCollider : MonoBehaviour
{
    CardPrefab cardPrefab;

    void Awake()
    {
        cardPrefab = this.gameObject.GetComponent<CardPrefab>();
    }

    void OnMouseDown() // 마우스 클릭시 콜라이더를 감지함, 터치도 된다! 
    {
        if (cardPrefab.state == CardState.Mulligun)
        {
            cardPrefab.state = CardState.Change;
            cardPrefab.cardXmark.SetActive(true);
        }
        else if (cardPrefab.state == CardState.Change)
        {
            cardPrefab.state = CardState.Mulligun;
            cardPrefab.cardXmark.SetActive(false);
        }
        else if (cardPrefab.state == CardState.Hand)
        {

        }
        else if (cardPrefab.state == CardState.Field)
        {

        }
    }

    void OnMouseUp() // 마우스를 뗄 떼 감지함 
    {

    }
}
