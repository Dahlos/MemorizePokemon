using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{

    static GameManager instance;
    public int selectedCards = 0;
    public StateSelectCard stateSelectCard = StateSelectCard.selectedZero;
    public GameObject selectedCardOne;
    public GameObject selectedCardTwo;
    public static GameManager GetInstance()
    {

        if (instance == null)
        {
            instance = new GameManager();
            return instance;
        }

        return instance;
    }

    public void IncrementSelectedCard(int val)
    {
        if (selectedCards == 2)
            return;
        selectedCards += val;
    }

    internal void SetCardSelected(GameObject cardSelected)
    {
        switch (stateSelectCard)
        {
            case StateSelectCard.selectedZero:
                selectedCardOne = null;
                selectedCardTwo = null;
                break;
            case StateSelectCard.selectedOne:
                selectedCardOne = cardSelected;
                break;
            case StateSelectCard.selectedTwo:
                selectedCardTwo = cardSelected;
                break;
        }
    }

    public bool AreSamePokemon()
    {
        return selectedCardOne.GetComponent<CardController>().PokemonName.Equals(selectedCardTwo.GetComponent<CardController>().PokemonName);
    }

    public void DisableCardEquals()
    {
        selectedCardOne.SetActive(false);
        selectedCardTwo.SetActive(false);
    }
}
public enum StateSelectCard
{
    selectedZero,
    selectedOne,
    selectedTwo
}