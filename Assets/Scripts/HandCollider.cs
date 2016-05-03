using UnityEngine;
using System.Collections;

public class HandCollider : MonoBehaviour {

    public DeckManager card;
    
    void OnMouseDown() // 마우스 클릭시 콜라이더를 감지함, 터치도 된다! 
    {
        card.TestCard();
        this.gameObject.SetActive(false);
    }
}
