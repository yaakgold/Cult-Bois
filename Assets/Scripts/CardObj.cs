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
        CardActions.Instance.CallAction(card.cardName);
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
