using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField] private float robotCost = 10;
    [SerializeField] private float lmbUpgCost = 4;
    [SerializeField] private float rmbBuyCost = 100;
    [SerializeField] private float rmbCptUpgCost = 15;
    [SerializeField] private float rmbCycleUpgCost = 25;
    [SerializeField] private float rmbCdUpgCost = 20;

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
            robotCost *= 1.25f;
        }
    }
    public void UpgradeLMBClick()
    {
        if (coinsScript.IsEnoughCoinsToBuy(lmbUpgCost))
        {
            coinsScript.AddCoins(-lmbUpgCost);
            lmbClickerScript.coinsPerClick++;
        }
    }
    public void BuyRMBClicker()
    {
        if (coinsScript.IsEnoughCoinsToBuy(rmbBuyCost))
        {
            coinsScript.AddCoins(-rmbBuyCost);
        }
    }

    public void UpgradeRMBCPT()
    {
        if (coinsScript.IsEnoughCoinsToBuy(rmbCptUpgCost))
        {
            coinsScript.AddCoins(-rmbCptUpgCost);
            rmbClickerScript.coinsPerTick += 0.01f;
        }
    }

    public void UpgradeRMBCycleTime()
    {
        if (coinsScript.IsEnoughCoinsToBuy(rmbCycleUpgCost))
        {
            coinsScript.AddCoins(-rmbCycleUpgCost);
            rmbClickerScript.cycleTime += 0.05f;
        }
    }

    public void UpgradeRMBCdTime()
    {
        if (coinsScript.IsEnoughCoinsToBuy(rmbCdUpgCost))
        {
            coinsScript.AddCoins(-rmbCdUpgCost);
            rmbClickerScript.cooldownTime -= 0.03f;
        }
    }

}