using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LMBClicker : MonoBehaviour
{
    public int coinsPerClick = 1;

    [SerializeField] private IsCursorOnABitcoin isCursorOnABitcoinScript;

    private Coins coinsScript;

    private void Awake()
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
