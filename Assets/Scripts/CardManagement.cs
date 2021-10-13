using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public CardsIn CardIn;
    public CardsOut CardsOut;
    public GameObject CardPrefab;
    

    public void MoveCardToStash(Card card)
    {
        CardIn.AddCard(card);

    }


    public void DrawCard(Card card)
    {
        GameObject go = Instantiate(CardPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        go.GetComponent<CardDisplay>().card = card;
        go.transform.parent = transform;

    }

    public int GetCardAmount()
    {
        return GetComponentsInChildren<CardDisplay>().Length;
    }


    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
