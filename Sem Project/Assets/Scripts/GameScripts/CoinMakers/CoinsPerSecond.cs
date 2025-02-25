using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Coins))]
public class CoinsPerSecond : MonoBehaviour
{
    public int amountOfRobots;

    private Coins coinsScript;

    private const int _delay = 1;

    private void Awake()
    {
        coinsScript = GetComponent<Coins>();
        StartCoroutine(GetCPS());
    }

    private IEnumerator GetCPS()
    {
        while (true)
        {
            coinsScript.AddCoins(amountOfRobots);
            yield return new WaitForSeconds(_delay);
        }
    }
}