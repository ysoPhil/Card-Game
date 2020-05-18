using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{

    List<Card> cards;


    private void Start()
    {
        cards.Clear();
        EventManager.current.InitializeDeck += onInitializeDeck;
        EventManager.current.InitializeDeckTrigger();
    
    }

    public void onInitializeDeck(List<CardData> data)
    {
        foreach (var d in data)
        {
            cards.Add(new Card(d));
        }
        test();
    }

    public void test()
    {
        foreach(Card card in cards)
        {
            Instantiate(card);
        }
    }
}
