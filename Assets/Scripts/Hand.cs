using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hand : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public List<CardObj> cardObjs = new List<CardObj>();
    public GameObject cardPref;
    public float spacing;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
        transform.localPosition = new Vector3(0, transform.localPosition.y - 80, 0);

        DrawCard();
        DrawCard();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.position = startPos;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 80, transform.localPosition.z);
    }

    public Card DrawCard()
    {
        Card c = Deck.Instance.TakeTopCard();

        if (c == null)
            return null;

        var card = Instantiate(cardPref, transform);

        card.GetComponent<CardObj>().SetCard(c);
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
