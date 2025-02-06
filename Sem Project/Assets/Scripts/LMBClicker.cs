using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LMBClicker : MonoBehaviour
{
    public int coinsPerClick = 1; //Amount of coins you get each LMB click

    [SerializeField] private IsCursorOnABitcoin isCursorOnABitcoinScript;

    private Coins coinsScript;

    private void Start()
    {
        coinsScript = GetComponent<Coins>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isCursorOnABitcoinScript.isCursorOnABitcoin)
        {
            coinsScript.AddCoins(coinsPerClick);
        }
    }
}
