using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> cardList;

    public static Card TakeTopCard(ref List<Card> cards)
    {
        Card c = null;
        if (cards.Count > 0)
            c = cards[0];
        cards.Remove(c);

        return c;
    }

    public List<Card> GetShuffledDeck()
    {
        List<Card> original = new List<Card>();
        foreach (var item in cardList)
        {
            original.Add(item);
        }

        List<Card> shuffle = new List<Card>();

        while (original.Count > 0)
        {
            int i = Random.Range(0, original.Count);
            shuffle.Add(original[i]);
            original.RemoveAt(i);
        }

        return shuffle;
    }
}
