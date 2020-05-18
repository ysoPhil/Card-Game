using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public Action<List<CardData>> InitializeDeck;

    [SerializeField]
    private List<CardData> deck;

    public static EventManager current;

    private void Awake()
    {
        current = this;
    }

    public void InitializeDeckTrigger()
    {
        InitializeDeck?.Invoke(deck);
    }
}
