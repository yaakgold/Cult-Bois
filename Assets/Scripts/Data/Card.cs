using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Card", menuName = "Data/Card")]
public class Card : ScriptableObject
{
    public string cardName = "";
    public string cardDesc = ""; //TODO: Figure out what I a doing with this
    public Sprite cardImage = null;
    public int cardCost = 0;
    public eCardType cardType = eCardType.MONSTER;
}

public enum eCardType
{
    MONSTER,
    SPELL
}