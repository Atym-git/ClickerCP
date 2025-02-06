using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Coins))]
public class CoinsPerSecond : MonoBehaviour
{
    public int amountOfRobots;
    private float robotCost = 10;
    private Coins coinsScript;


    private void Start()
    {
        coinsScript = GetComponent<Coins>();
        StartCoroutine(GetCPS());
    }
    

    private IEnumerator GetCPS()
    {
        while (true)
        {
        coinsScript.AddCoins(amountOfRobots);
        yield return new WaitForSeconds(1f);
        }
    }


}
