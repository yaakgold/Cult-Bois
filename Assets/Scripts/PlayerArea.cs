using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerArea : MonoBehaviour, IPointerClickHandler
{
    public Hand hand;
    public List<CardObj> cardObjs = new List<CardObj>();
    public float spacing, startSpace;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (hand.currentCardHolding == null)
            return;
        
        if (GameManager.Instance.followers < hand.currentCardHolding.card.cardCost)
            return;

        GameManager.Instance.followers -= hand.currentCardHolding.card.cardCost;
        AddCardToPlayArea(hand.currentCardHolding);
    }

    public void AddCardToPlayArea(CardObj card)
    {
        hand.currentCardHolding = null;
        hand.cardObjs.Remove(card);

        card.cardIsInPlay = true;
        card.transform.SetParent(transform);
        card.canvasGroup.blocksRaycasts = true;
        card.isFollowingHand = false;
        card.cardIsInHand = false;
        cardObjs.Add(card);
        CardPositions();
    }

    public void CallActions()
    {
        //TODO: Change this system to not use the CallAction class, this should be removed cause it was a bad idea
        foreach (var c in cardObjs)
        {
            CardActions.Instance.CallAction(c.card.cardName);
        }
    }

    public void CardPositions()
    {
        for (int i = 0; i < cardObjs.Count; i++)
        {
            //TODO: Make this not be starting at center, and make all cards move around the center
            cardObjs[i].gameObject.transform.localPosition = new Vector3(i * spacing - ((cardObjs.Count - 1) * startSpace), 0);
        }
    }
}
