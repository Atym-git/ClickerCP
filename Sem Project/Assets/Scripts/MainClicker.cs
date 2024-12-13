using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainClicker : MonoBehaviour
{
    public float amountOfCoins = 0; //Overall amount of Coins

    public int coinsPerClick; //Amount of coins you get each LMB click

    [SerializeField] private IsCursorOnABitcoin isCursorOnABitcoinScript;

    [SerializeField] private TextMeshProUGUI showingAmountOfclicks;

    private void Update()
    {
        BitcoinLMBClick();
        ShowANDConvertCurrencies();
    }

    private void BitcoinLMBClick()
    {
        
        if (Input.GetMouseButtonUp(0) && isCursorOnABitcoinScript.isCursorOnABitcoin)
        {
            amountOfCoins += coinsPerClick;
        }
    }

    private void ShowANDConvertCurrencies() // To Do: Fix currencies's converts
    {
        if (amountOfCoins >= 1000)
        {
            showingAmountOfclicks.text = $"{amountOfCoins / 1000}K";
        }
        if (amountOfCoins >= 1000000)
        {
            showingAmountOfclicks.text = $"{amountOfCoins / 1000000}M";
        }
        if (amountOfCoins >= 1000000000)
        {
            showingAmountOfclicks.text = $"{amountOfCoins / 1000000000}B";
        }
        showingAmountOfclicks.text = amountOfCoins.ToString();
    }

}
