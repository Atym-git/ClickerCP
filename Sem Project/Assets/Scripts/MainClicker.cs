using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainClicker : MonoBehaviour
{
    public float amountOfCoins = 0;

    public int coinsPerClick; //Amount of clicks you get per each click on LMB

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
            Debug.Log("We clicked the bitcoin");
            amountOfCoins += coinsPerClick;
        }
    }

    private void ShowANDConvertCurrencies()
    {
        showingAmountOfclicks.text = amountOfCoins.ToString();
        if (amountOfCoins >= 1000)
        {
            amountOfCoins /= 1000;
            showingAmountOfclicks.text = $"{amountOfCoins}K";
        }
        if (amountOfCoins >= 1000000)
        {
            amountOfCoins /= 1000000;
            showingAmountOfclicks.text = $"{amountOfCoins}M";
        }
        if (amountOfCoins >= 1000000000)
        {
            amountOfCoins /= 1000000000;
            showingAmountOfclicks.text = $"{amountOfCoins}B";
        }
    }

}
