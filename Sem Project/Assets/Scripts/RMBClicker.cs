using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MainClicker))]
[RequireComponent(typeof(IsCursorOnABitcoin))]
public class RMBClicker : MonoBehaviour
{
    [SerializeField] private int startingRMBPower; // How much you get insantly after you press RMB button
    private int currentRMBPower;
    private float timeEachTick = 0.03f; // Each time you get an extra RMBPower / Overall time divided by 100
    [SerializeField] private int startingpowerMultiplayer;
    private int currentpowerMultiplayer = 3; // How more is max power compared to min power

    [SerializeField] private MainClicker mainClicker;
    [SerializeField] private IsCursorOnABitcoin isCursorOnABitcoinScript;


    private void Start()
    {

        currentRMBPower = startingRMBPower;
        currentpowerMultiplayer = startingpowerMultiplayer;
    }

    private void Update()
    {
        RMBButtonDown();

    }


    private void RMBButtonDown()
    {
        if (Input.GetMouseButtonDown(1) && isCursorOnABitcoinScript.isCursorOnABitcoin)
        {
        StartCoroutine(AddingPower());
        }

    }

    




    private IEnumerator AddingPower()
    {
        while (currentRMBPower <= startingRMBPower * currentpowerMultiplayer)
        {
            if (Input.GetMouseButtonUp(1))
            {
                mainClicker.amountOfCoins += currentRMBPower;
                currentRMBPower = startingRMBPower;
                break;
            }
            Debug.Log(currentRMBPower);
            currentRMBPower++;
            yield return new WaitForSeconds(timeEachTick);   
        }
    }


}
