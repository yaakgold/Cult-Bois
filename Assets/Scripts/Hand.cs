using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hand : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public List<CardObj> cardObjs = new List<CardObj>();
    public GameObject cardPref;
    public float spacing;
    public Transform canvas;
    public CardObj currentCardHolding = null;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
        transform.localPosition = new Vector3(0, transform.localPosition.y - 80, 0);

        DrawCard();
        DrawCard();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(currentCardHolding)
        {
            currentCardHolding.OnPointerClick(null);
            currentCardHolding.transform.SetParent(transform);
            currentCardHolding.canvasGroup.blocksRaycasts = true;
            CardPositions();

            currentCardHolding = null;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.position = startPos;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.position = new Vector3(startPos.x, startPos.y - 80, startPos.z);
    }

    public Card DrawCard()
    {
        Card c = Deck.Instance.TakeTopCard();

        if (c == null)
            return null;

        var card = Instantiate(cardPref, transform);

        card.GetComponent<CardObj>().SetCard(c);
        card.GetComponent<CardObj>().canvas = canvas;
        card.GetComponent<CardObj>().hand = this;

        cardObjs.Add(card.GetComponent<CardObj>());
        CardPositions();

        return c;
    }

    public void CardPositions()
    {
        for (int i = 0; i < cardObjs.Count; i++)
        {
            cardObjs[i].gameObject.transform.localPosition = new Vector3(i * spacing, 0);
        }
    }
}
