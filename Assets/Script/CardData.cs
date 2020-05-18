using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CardType { Attack, Ability }

[CreateAssetMenu (fileName ="New Card", menuName = "Card")]

public class CardData : ScriptableObject
{
    [SerializeField]
    string card_name;

    [SerializeField]
    string card_value;

    [SerializeField]
    Sprite artwork;

    [SerializeField]
    CardType card_type;

    public string getCardName() { return this.card_name; }
    public string getCardValue() { return this.card_value; }
    public Sprite getCardArtwork() { return this.artwork; }
    public CardType getCardType() { return this.card_type; }
}
