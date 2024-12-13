using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(MainClicker))]
[RequireComponent(typeof(IsCursorOnABitcoin))]
public class RMBClicker : MonoBehaviour
{
    [Header("RMBClicker")]
    private bool isRMBClickerBought; // To do: Make a UI panel with an opportunity to buy RMBClicker, autoclicks, etc.
    [SerializeField] private float maxRMBPower = 10; // If you time this number by currentRMBMultiplayer & by currTime you will get how much is the maxRMBPower "RMBTimer" amount of time
    private float currentRMBPower;
    private float RMBTimer = 3f; //How much time you can hold RMB rn (To Do: it is should be upgreadable)
    private float currTime = 1; // How much time has passed since you started to hold down the rmb button
    private float currentRMBMultiplayer = 3f; // To Do: Use this value to multiply the value of maxRMBPower (need to find a balance with currtime)
    [Header("Cooldown")]
    private float cooldownTime = 10f;

    [Header("Scripts")]
    [SerializeField] private MainClicker mainClicker;
    [SerializeField] private IsCursorOnABitcoin isCursorOnABitcoinScript;

    private void Update()
    {
        RMBButtonDown();
        RMBButtonUp();
    }
    private void RMBButtonDown()
    {
        //if (isRMBClickerBought)
        //{
            if (Input.GetMouseButton(1) && isCursorOnABitcoinScript.isCursorOnABitcoin && currTime <= RMBTimer + 1)
            {
                currTime += Time.deltaTime;
            }
        //}
    }

    private void RMBButtonUp()
    {
        if (Input.GetMouseButtonUp(1))
        {
            currentRMBPower = maxRMBPower * (currTime - 1);
            mainClicker.amountOfCoins += currentRMBPower;
            currTime = 1;
            Cooldown();
        }
    }

    private void Cooldown()
    {
        //To Do: add a cooldown (timer) between RMB clicks so you can't start a new one instantly after the last one ended using cooldownTime
    }

}
