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
        foreach (var item in cardObjs)
        {
            foreach (var action in item.card.cardActionTypes)
            {
                switch (action.actionType)
                {
                    case eActionType.ATTACK:
                        GameManager.Instance.enemy.TakeDamage((int)action.amount);
                        break;
                    case eActionType.DISCARD:
                        //Set this up because I need to redo cards
                        break;
                    case eActionType.DRAW:
                        for (int i = 0; i < action.amount; i++)
                        {
                            hand.DrawCard();
                        }
                        break;
                    case eActionType.TAKE_FOLLOWERS:
                        //See discard
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public void CardPositions()
    {
        for (int i = 0; i < cardObjs.Count; i++)
        {
            var xLoc = i * spacing - ((cardObjs.Count - 1) * startSpace);
            cardObjs[i].gameObject.transform.localPosition = new Vector3(xLoc, 0);
        }
    }
}
