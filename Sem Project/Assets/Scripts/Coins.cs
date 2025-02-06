using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    private float amountOfCoins = 0; //Overall amount of Coins

    [SerializeField] private TextMeshProUGUI showingAmountOfclicks;

    public void AddCoins(float coins)
    {
        amountOfCoins += coins;
        ShowANDConvertCurrencies();
    }

    public bool IsEnoughCoinsToBuy(float coins)
    {
        if (amountOfCoins - coins < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }    

    private void ShowANDConvertCurrencies() // To Do: Fix currencies's converts
    {
        //if (amountOfCoins >= 1000)
        //{
        //    showingAmountOfclicks.text = $"{amountOfCoins / 1000}K";
        //}
        //if (amountOfCoins >= 1000000)
        //{
        //    showingAmountOfclicks.text = $"{amountOfCoins / 1000000}M";
        //}
        //if (amountOfCoins >= 1000000000)
        //{
        //    showingAmountOfclicks.text = $"{amountOfCoins / 1000000000}B";
        //}
        showingAmountOfclicks.text = amountOfCoins.ToString();
    }

}
