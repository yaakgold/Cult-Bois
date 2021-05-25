using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArea : MonoBehaviour
{
    public List<CardObj> cardObjs = new List<CardObj>();
    public GameObject cardPref;
    public Transform canvas;
    public float spacing, startSpace;

    [SerializeField]
    private List<Card> deck;

    private void Start()
    {
        deck = GameManager.Instance.GetComponent<Deck>().GetShuffledDeck();

        //TODO: Remove this
        CreateCard();
        CreateCard();
    }

    //Change this to a draw method at some point
    private void CreateCard()
    {
        Card c = Deck.TakeTopCard(ref deck);

        if (c == null)
            return;

        var card = Instantiate(cardPref, transform);

        card.GetComponent<CardObj>().SetCard(c);
        card.GetComponent<CardObj>().canvasGroup.blocksRaycasts = false;
        card.GetComponent<CardObj>().cardState = eCardState.IN_PLAY_AREA;

        cardObjs.Add(card.GetComponent<CardObj>());
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
