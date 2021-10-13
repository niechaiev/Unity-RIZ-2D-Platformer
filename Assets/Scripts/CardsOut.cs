using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class CardsOut : MonoBehaviour
{
    private List<Card> cards = new List<Card>();
    public List<Card> staticCards = new List<Card>();

    public Text CardAmount;
    CardManagement cardManagement;
    public float Timer = 2;
    public int MaxCardAmount;
    public int CardInHandAmount;


    public List<Card> Cards { get => cards; set => cards = value; }

 
    // Start is called before the first frame update
    public bool DrawCard()
    {

       if(CardInHandAmount >= MaxCardAmount)
        {
            return false;
        }
        else
        {
            cardManagement.DrawCard(cards[0]);
            cards.RemoveAt(0);
            CardAmount.text = cards.Count().ToString();
            CardInHandAmount++;

            if (cards.Count == 0)
            {
                cards = cardManagement.CardIn.RetrieveCards();
                CardAmount.text = cards.Count().ToString();
                
            }

            return true;
        }

    }



    void Start()
    {
        cards = staticCards;
        CardAmount.text = cards.Count().ToString();
        cardManagement = transform.parent.Find("Hand").GetComponent<CardManagement>();
        CardInHandAmount = CardInHandAmount = cardManagement.GetCardAmount();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
