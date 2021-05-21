using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    #region Singleton
    private static Deck _instance;

    public static Deck Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance)
            Destroy(gameObject);
        else
            _instance = this;
    }
    #endregion

    public List<Card> cardList;

    public Card TakeTopCard()
    {
        Card c = null;
        if (cardList.Count > 0)
            c = cardList[0];
        cardList.Remove(c);

        return c;
    }
}
