using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CardsIn : MonoBehaviour
{

    List<Card> cards = new List<Card>();
    public Text CardAmount;
    CardManagement cardManagement;

    public List<Card> Cards { get => cards; set => cards = value; }

    internal void AddCard(Card card)
    {
        cards.Add(card);
        CardAmount.text = cards.Count().ToString();
       

    }

    public List<Card> RetrieveCards()
    {
        List<Card> copy = Cards;
        Cards = new List<Card>();
        CardAmount.text = "0";
        copy = copy.OrderBy(a => Guid.NewGuid()).ToList();
        return copy;
    }


    // Start is called before the first frame update

    void Start()
    {
        cardManagement = gameObject.GetComponentInParent<CardManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
