using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private CardData data;

    [Tooltip("Text Box for the card name")]
    public Text card_name;

    [Tooltip("Text Box for the card value")]
    public Text card_value;

    [Tooltip("Image for the card")]
    public Image card_artwork;

    public CardType card_type;

    public Card(CardData data)
    {
        this.data = data;
        this.card_name.text = data.getCardName();
        this.card_value.text = data.getCardValue();
        this.card_artwork.sprite = data.getCardArtwork();
        this.card_type = data.getCardType();
    }

}
