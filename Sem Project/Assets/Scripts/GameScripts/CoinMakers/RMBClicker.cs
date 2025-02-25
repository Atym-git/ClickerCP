using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Coins))]
public class RMBClicker : MonoBehaviour
{
    [Header("RMBClicker")]
    public bool isRMBBought = false;
    public float cycleTime = 3f;
    private float _currTime = 0;
    public float coinsPerTick = 0.1f;
    public float maxCooldownTime = 5f;
    public bool IsOnCooldown = false;

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
        if (isRMBBought)
        {
            if (Input.GetMouseButton(1) && isCursorOnABitcoinScript.isCursorOnABitcoin && !IsOnCooldown)
            {
                _currTime += Time.deltaTime;
                coinsScript.AddCoins(coinsPerTick);
            }
        }
    }

    private void RMBButtonUp()
    {
        if ((Input.GetMouseButtonUp(1) && _currTime > 0) || _currTime >= cycleTime)
        {
            StartCoroutine(Cooldown());
            _currTime = 0;
        }
    }

    private IEnumerator Cooldown()
    {
        IsOnCooldown = true;
        float cooldownTime = _currTime * (maxCooldownTime / cycleTime);
        yield return new WaitForSeconds(maxCooldownTime);
        IsOnCooldown = false;
    }

}
