using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CardObj : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Card card;
    public TMP_Text txtName, txtDesc, txtCost;
    public Image img;
    public Hand hand;
    public CanvasGroup canvasGroup;
    public Canvas canvas;
    public eCardState cardState = eCardState.IN_PLAYER_HAND;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
    }

    private void Update()
    {
        //Allow follow mouse
        if(cardState == eCardState.MOVING_AROUND)
        {
            transform.SetParent(canvas.transform);
            GetComponent<RectTransform>().anchoredPosition = Input.mousePosition;
        }
    }

    public void SetCard(Card c)
    {
        card = c;

        txtName.text = card.cardName;
        if(txtDesc)
            txtDesc.text = card.cardDesc;
        txtCost.text = card.cardCost.ToString();
        img.sprite = card.cardImage;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (cardState)
        {
            case eCardState.IN_PLAYER_HAND:
                cardState = eCardState.MOVING_AROUND;
                canvasGroup.blocksRaycasts = false;
                hand.currentCardHolding = this;
                break;
            case eCardState.MOVING_AROUND:
                break;
            case eCardState.IN_PLAY_AREA:
                break;
            case eCardState.SELECTING:
                break;
            case eCardState.CAN_BE_SELECTED:
                break;
            case eCardState.SELECTED:
                break;
            default:
                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = Vector3.one * 1.2f;
        transform.SetAsLastSibling();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = Vector3.one;
    }
}

public enum eCardState
{
    IN_PLAYER_HAND,
    MOVING_AROUND,
    IN_PLAY_AREA,
    SELECTING,
    CAN_BE_SELECTED,
    SELECTED
}