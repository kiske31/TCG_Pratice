using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum CardState
{
    None = 0, // 노멀 상태
    Mulligun, // 멀리건 상태
    Change, // 멀리건 예정인 카드 상태
    Hand, // 손패 상태
    Field, // 필드에 나간 상태
    GraveYard // 무덤으로 간 상태
}

public class CardPrefab : MonoBehaviour {
    
    public MeshRenderer CardFront;
    public MeshRenderer CardPhoto;
    public Text CardCost;
    public Text CardAtk;
    public Text CardHp;
    public Text CardName;
    public Text CardDesc;

    public int id;     // 카드 아이디
    public int atk;    // 카드 공격력
    public int hp;     // 카드 에너지
    public int type;   // 카드 타입
    public int value;  // 카드 특수 능력 밸류
    public int cost;   // 카드 마나 코스트
    public DeckManager deckManager; // 콜라이더에서 접근하려고 가지고 있을 필요가 있네.
    public CardState state;

    public void PrefabSetting(int id)
    {
        // 카드 프리펩 세팅

        Card newCard = CardManager.Instance.CardList[id];
        
        if (newCard.legendary)
        {
            CardFront.material = (Material)Resources.Load("legend");
        }
        else
        {
            if (newCard.type > 5)
            {
                CardFront.material = (Material)Resources.Load("magic");
            }
            else
            {
                CardFront.material = (Material)Resources.Load("normal");
            }
        }

        if (newCard.type < 6)
        {
            CardAtk.text = newCard.attack.ToString();
            CardHp.text = newCard.hp.ToString();
        }
        else
        {
            CardAtk.text = "";
            CardHp.text = "";
        }

        CardPhoto.material = (Material)Resources.Load("Lobby");
        // CardPhoto.material = (Material)Resources.Load(newCard.prefabPath);
        CardName.text = newCard.name;
        CardDesc.text = newCard.description;
        CardCost.text = newCard.mana.ToString();

        // 카드 수치 세팅

        this.id = newCard.id;
        type = newCard.type;
        value = newCard.ability;
        cost = newCard.mana;
        atk = newCard.attack;
        hp = newCard.hp;
        state = CardState.None;
    }

    public void DeckManagerLink(DeckManager deckMgr)
    {
        deckManager = deckMgr;
    }

    public void SetAtk(int value)
    {
        if (type > 5) return;

        atk += value;
        if (atk < 0) atk = 0;
        CardAtk.text = atk.ToString();
    }

    public void SetHp(int value)
    {
        if (type > 5) return;

        hp += value;
        if (hp < 0) hp = 0;
        CardHp.text = hp.ToString();
    }

    public void SetToken()
    {
        if (type > 5) return;

        PrefabSetting(36);
    }
}
