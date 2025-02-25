using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Coins))]
[RequireComponent(typeof(CoinsPerSecond))]
[RequireComponent(typeof(LMBClicker))]
[RequireComponent(typeof(RMBClicker))]
public class Store : MonoBehaviour
{
    [Header("Prices")]
    public float robotCost = 10;
    public float lmbUpgCost = 4;
    public float rmbBuyCost = 100;
    public float rmbCptUpgCost = 15;
    public float rmbCycleUpgCost = 25;
    public float rmbCdUpgCost = 20;

    [SerializeField] private float _upgradeMultiplayer = 1.25f;

    [Header("Scripts")]
    private Coins coinsScript;
    private CoinsPerSecond coinsPerSecondScript;
    private LMBClicker lmbClickerScript;
    private RMBClicker rmbClickerScript;

    private void Awake()
    {
        coinsScript = GetComponent<Coins>();
        coinsPerSecondScript = GetComponent<CoinsPerSecond>();
        lmbClickerScript = GetComponent<LMBClicker>();
        rmbClickerScript = GetComponent<RMBClicker>();
    }

    public void HireARobot()
    {
        if (coinsScript.IsEnoughCoinsToBuy(robotCost))
        {
            coinsScript.AddCoins(-robotCost);
            coinsPerSecondScript.amountOfRobots++;
            robotCost *= _upgradeMultiplayer;
        }
    }
    public void UpgradeLMBClick()
    {
        if (coinsScript.IsEnoughCoinsToBuy(lmbUpgCost))
        {
            coinsScript.AddCoins(-lmbUpgCost);
            lmbClickerScript.coinsPerClick++;
            lmbUpgCost *= _upgradeMultiplayer;
        }
    }
    public void BuyRMBClicker()
    {
        if (!rmbClickerScript.isRMBBought && coinsScript.IsEnoughCoinsToBuy(rmbBuyCost))
        {
            coinsScript.AddCoins(-rmbBuyCost);
            rmbClickerScript.isRMBBought = true;
        }
    }

    public void UpgradeRMBCPT()
    {
        if (coinsScript.IsEnoughCoinsToBuy(rmbCptUpgCost))
        {
            coinsScript.AddCoins(-rmbCptUpgCost);
            rmbClickerScript.coinsPerTick += 0.01f;
            rmbCptUpgCost *= _upgradeMultiplayer;
        }
    }

    public void UpgradeRMBCycleTime()
    {
        if (coinsScript.IsEnoughCoinsToBuy(rmbCycleUpgCost))
        {
            coinsScript.AddCoins(-rmbCycleUpgCost);
            rmbClickerScript.cycleTime += 0.05f;
            rmbCycleUpgCost *= _upgradeMultiplayer;
        }
    }

    public void UpgradeRMBCdTime()
    {
        if (coinsScript.IsEnoughCoinsToBuy(rmbCdUpgCost))
        {
            coinsScript.AddCoins(-rmbCdUpgCost);
            rmbClickerScript.maxCooldownTime -= 0.03f;
            rmbCdUpgCost *= _upgradeMultiplayer;
        }
    }
}