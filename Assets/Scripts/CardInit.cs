using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardInit : MonoBehaviour
{
    // Start is called before the first frame update
    public Card Card;
    void Start()
    {
        var objectTitle = GameObject.Find("Card Title");
        objectTitle.GetComponent<Text>().text = Card.Title;
        var objectDesc = GameObject.Find("Card Description");
        objectTitle.GetComponent<Text>().text = Card.Description;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
