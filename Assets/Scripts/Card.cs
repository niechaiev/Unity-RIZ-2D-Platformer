using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName ="Card")]
public class Card : ScriptableObject 
{
    public string Title;
    public string Description;
    public string Classification;

    public int ManaCost;
    public int damage;
    public int radius;
    public Sprite sprite;

    public bool isInstant = true;

    public GameObject effect;

}
