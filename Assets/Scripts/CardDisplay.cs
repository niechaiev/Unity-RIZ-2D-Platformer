using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Card card;

    public Text title;
    public Text description;
    public Text notEnough;
    public Image image;
   



    void Start()
    {
        title.text = card.Title;
        description.text = card.Description;
        description.text += "\nDamage: " + card.damage.ToString();
        description.text += "\nRadius: " + card.radius.ToString();
        description.text += "\nMana cost: " + card.ManaCost.ToString();
        image.sprite = card.sprite;
    
    }


}
