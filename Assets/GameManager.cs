using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int selectedCards;
    void Start()
    {
        selectedCards = 0;
    }

    void Update()
    {

    }

    public void SelectCard(int num)
    {
        selectedCards += num;
    }
}
