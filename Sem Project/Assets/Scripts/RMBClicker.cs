using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Coins))]
public class RMBClicker : MonoBehaviour
{
    [Header("RMBClicker")]
    public bool isRMBClickerBought = false; // To do: Make a UI panel with an opportunity to buy RMBClicker, autoclicks, etc.
    public float cycleTime = 3f; //How much time you can hold RMB rn (To Do: it is should be upgreadable)
    private float currTime = 0; // How much time has passed since you started to hold down the rmb button
    public float coinsPerTick = 0.1f;
    public float cooldownTime = 5f;
    private bool isOnCooldown = false;

    [Header("Scripts")]
    [SerializeField] private Coins coinsScript;
    [SerializeField] private IsCursorOnABitcoin isCursorOnABitcoinScript;

    private void FixedUpdate()
    {
        RMBButtonDown();
        RMBButtonUp();
    }
    private void RMBButtonDown()
    {
        //if (isRMBClickerBought)
        //{
            if (Input.GetMouseButton(1) && isCursorOnABitcoinScript.isCursorOnABitcoin && !isOnCooldown)
            {
            currTime += Time.deltaTime;
            coinsScript.AddCoins(coinsPerTick);
            }
        //}
    }

    private void RMBButtonUp()
    {
        if ((Input.GetMouseButtonUp(1) && currTime > 0) || currTime >= cycleTime)
        {
            currTime = 0;
            StartCoroutine(Cooldown());
        }
    }

    private IEnumerator Cooldown()
    {
        Debug.Log(isOnCooldown);
        isOnCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isOnCooldown = false;
        Debug.Log(isOnCooldown);
    }

}
