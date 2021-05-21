using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardActions : MonoBehaviour
{
    #region Singleton
    private static CardActions _instance;

    public static CardActions Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance)
            Destroy(gameObject);
        else
            _instance = this;
    }
    #endregion

    //              Card name, Function of action
    public Dictionary<string, CardActionDelegate[]> cardActionList = new Dictionary<string, CardActionDelegate[]>();

    public delegate bool CardActionDelegate();

    /// <summary>
    /// Use this method to load in all of the methods for the Dictionary
    /// </summary>
    private void Start()
    {
        GoldbergMethod();
        SalemMethod();
        HoffmanMethod();
        TyMethod();
    }

    private void GoldbergMethod()
    {
        cardActionList.Add("Temp Card 1", new CardActionDelegate[] { CardTestAction, CardTestAction2 });
    }

    private void SalemMethod()
    {

    }

    private void HoffmanMethod()
    {

    }

    private void TyMethod()
    {

    }

    public bool CallAction(string cardName)
    {
        if (!cardActionList.TryGetValue(cardName, out CardActionDelegate[] actions))
            return false;

        bool fullSuccess = true;
        for (int i = 0; i < actions.Length; i++)
        {
            if (!actions[i].Invoke())
                fullSuccess = false;
        }

        return fullSuccess;
    }

    public bool CardTestAction()
    {
        print("This worked");

        return true;
    }

    public bool CardTestAction2()
    {
        print("This also worked");

        return true;
    }
}
