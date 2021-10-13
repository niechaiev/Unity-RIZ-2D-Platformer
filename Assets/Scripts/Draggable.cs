using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    Card myCard;
    CardManagement cardManagement;
    GameHandler gameHandler;
    Text NotEnough;

    CardsOut cardsOut;

    public Transform parentToReturnTo;
    public Transform placeholderParent = null;
    GameObject placeholder = null;
    public bool exited = false;

    public void Start()
    {
        parentToReturnTo = transform.parent;
        myCard = GetComponent<CardDisplay>().card;
        cardManagement = gameObject.GetComponentInParent<CardManagement>();
        gameHandler = FindObjectOfType<GameHandler>();

        NotEnough = transform.parent.parent.Find("NotEnough").GetComponent<Text>();
        cardsOut = transform.root.Find("CardsOut").GetComponent<CardsOut>();

    }

    public void OnBeginDrag(PointerEventData eventData)
    {

        //transform.SetParent(transform.parent.parent);

        placeholder = new GameObject();
        placeholder.transform.SetParent(this.transform.parent);
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleWidth = 0;
        le.flexibleHeight = 0;

        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        parentToReturnTo = this.transform.parent;
        placeholderParent = parentToReturnTo;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;

        if (placeholder.transform.parent != placeholderParent)
            placeholder.transform.SetParent(placeholderParent);

        int newSiblingIndex = placeholderParent.childCount;

        for (int i = 0; i < placeholderParent.childCount; i++)
        {
            if (this.transform.position.x < placeholderParent.GetChild(i).position.x)
            {

                newSiblingIndex = i;

                if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                    newSiblingIndex--;

                break;
            }
        }

        placeholder.transform.SetSiblingIndex(newSiblingIndex);
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (myCard.ManaCost > gameHandler.manaSystem.GetMana() )
        {
            transform.SetParent(parentToReturnTo);
            transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            Destroy(placeholder);
            StartCoroutine(ShowMessage("Not enough mana", 1));
            return;
        }
        else if (!exited) {
            transform.SetParent(parentToReturnTo);
            transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            Destroy(placeholder);
        }
        else if (exited) {

            gameHandler.manaSystem.Reduce(myCard.ManaCost);
            cardsOut.CardInHandAmount--;


            cardManagement.MoveCardToStash(myCard);



            var pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            GameObject newObject = Instantiate(myCard.effect, pos, new Quaternion());
            newObject.GetComponent<EffectCollide>().Damage = GetComponent<CardDisplay>().card.damage;
            newObject.GetComponent<CircleCollider2D>().radius = GetComponent<CardDisplay>().card.radius;
            newObject.GetComponent<EffectCollide>().IsInstant = GetComponent<CardDisplay>().card.isInstant;
            Destroy(placeholder);
            Destroy(gameObject);

        }




    }

    IEnumerator ShowMessage(string message, float delay)
    {
        NotEnough.text = message;
        NotEnough.enabled = true;
        yield return new WaitForSeconds(delay);
        NotEnough.enabled = false;
    }

}

