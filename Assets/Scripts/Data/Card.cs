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
    public int health;
    public int damage;
    public eFollowerType cardFollowerType;
    public eCardType cardType = eCardType.MONSTER;

    [HideInInspector]
    [SerializeField]
    public List<CardActionTypes> cardActionTypes;

    [HideInInspector]
    [SerializeField]
    public eFollowerType typeOfFollowerForMana;
}

[System.Serializable]
public class CardActionTypes
{
    [SerializeField]
    public eActionType actionType;
    [SerializeField]
    public float amount;
}

public enum eCardType
{
    FOLLOWER,
    MONSTER,
    INSTANT
}

public enum eActionType
{
    ATTACK,
    DISCARD,
    DRAW,
    TAKE_FOLLOWERS
}

public enum eFollowerType
{
    DEVOUT,
    BASIC,
    OTHERS
}