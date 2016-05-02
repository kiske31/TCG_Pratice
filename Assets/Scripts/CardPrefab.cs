using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardPrefab : MonoBehaviour {
    
    public MeshRenderer CardFront;
    public MeshRenderer CardPhoto;
    public Text CardCost;
    public Text CardAtk;
    public Text CardHp;
    public Text CardName;
    public Text CardDesc;



    // Use this for initialization
    void Awake()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void PrefabSetting(int id)
    {
        Card newCard = CardManager.Instance.CardList[id];

        //  if (newCard.legendary)
        //  {
        //      CardFront.material = (Material)Resources.Load("legendary");
        //  }
        if (newCard.legendary)
        {
            CardFront.material = (Material)Resources.Load("leged");
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
        
        // CardPhoto.material = (Material)Resources.Load(newCard.prefabPath);
        CardPhoto.material = (Material)Resources.Load("Lobby");
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
        CardName.text = newCard.name;
        CardDesc.text = newCard.description;
        CardCost.text = newCard.mana.ToString();
    }
}
