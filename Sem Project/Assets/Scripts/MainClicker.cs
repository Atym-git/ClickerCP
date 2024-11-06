using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainClicker : MonoBehaviour
{
    public float amountOfCoins;

    private int coinsPerClick; //Amount of clicks you get per each click on LMB

    [SerializeField] public Image bitcoinPlacement;
    [SerializeField] private Camera MainCamera;

    [SerializeField] private TextMeshProUGUI showingAmountOfclicks;

    private void Update()
    {
        BitcoinLMBClick();
        ShowANDConvertCurrencies();
    }

    private void BitcoinLMBClick()
    {
        Vector2 mousePosition = Input.mousePosition;

        Ray cursorTrackerRay = MainCamera.ScreenPointToRay(mousePosition);
        RaycastHit hitAnything; // Not exactly the bitcoin
        
        bool weHitSomething = Physics.Raycast(cursorTrackerRay, out hitAnything);

        if (Input.GetMouseButton(0) && weHitSomething && hitAnything.transform.GetComponent<BoxCollider2D>())
        {
            amountOfCoins += coinsPerClick;
        }

    }

    private void ShowANDConvertCurrencies()
    {
        showingAmountOfclicks.text = amountOfCoins.ToString();
        if (amountOfCoins >= 100000)
        {
            amountOfCoins /= 100;
            showingAmountOfclicks.text = $"{amountOfCoins}K";
        }
        if (amountOfCoins >= 1000000)
        {
            amountOfCoins /= 1000;
            showingAmountOfclicks.text = $"{amountOfCoins}M";
        }
        if (amountOfCoins >= 10000000)
        {
            amountOfCoins /= 10000;
            showingAmountOfclicks.text = $"{amountOfCoins}B";
        }
    }

}
