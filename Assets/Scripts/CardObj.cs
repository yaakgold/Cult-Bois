using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CardObj : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Transform canvas;
    public Card card;
    public TMP_Text txtName, txtDesc, txtCost;
    public Image img;
    public bool cardIsInHand = true;
    public bool cardIsInPlay = false;
    public bool isFollowingHand = false;
    public Hand hand;
    public CanvasGroup canvasGroup;

    private Transform startParent;

    private void Start()
    {
        startParent = transform.parent;
    }

    private void Update()
    {
        if (isFollowingHand)
        {
            if(transform.parent.TryGetComponent(out Hand h))
            {
                h.OnPointerExit(null);
            }

            transform.SetParent(canvas);
            transform.localScale = Vector3.one;
            canvasGroup.blocksRaycasts = false;

            GetComponent<RectTransform>().anchoredPosition = Input.mousePosition;
        }
        else if(transform.parent == null)
        {
            transform.SetParent(startParent);
            startParent.GetComponent<Hand>().CardPositions();
            canvasGroup.blocksRaycasts = true;
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
        if(cardIsInPlay)
        {

        }
        else
        {
            isFollowingHand = !isFollowingHand;

            if (hand.currentCardHolding == null)
                hand.currentCardHolding = this;
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
