using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactables : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private Coins coinsScript;
    [SerializeField] private RMBClicker rmbClickerScript;
    [SerializeField] private Store storeScript;

    [Header("Buttons")]
    [SerializeField] private Button _lmbUpgrageButton;
    [SerializeField] private Button _buyRobotButton;
    [SerializeField] private Button _buyRmbButton;
    [SerializeField] private Button _rmbCptUpgButton;
    [SerializeField] private Button _rmbCycleUpgButton;
    [SerializeField] private Button _rmbCdUpgButton;

    public void SwitchInteractables()
    {
        BuyRobot();
        UpgradeLMBClicker();
        BuyRMB();
        RMBUpgCpt();
        RMBUpgCycle();
        RMBUpgCdTime();
    }

    private void RMBUpgCdTime()
    {
        if (rmbClickerScript.isRMBBought && coinsScript.IsEnoughCoinsToBuy(storeScript.rmbCdUpgCost))
        {
            _rmbCdUpgButton.interactable = true;
        }
        else
        {
            _rmbCdUpgButton.interactable = false;
        }
    }

    private void RMBUpgCycle()
    {
        if (rmbClickerScript.isRMBBought && coinsScript.IsEnoughCoinsToBuy(storeScript.rmbCycleUpgCost))
        {
            _rmbCycleUpgButton.interactable = true;
        }
        else
        {
            _rmbCycleUpgButton.interactable = false;
        }
    }

    private void RMBUpgCpt()
    {
        if (rmbClickerScript.isRMBBought && coinsScript.IsEnoughCoinsToBuy(storeScript.rmbCptUpgCost))
        {
            _rmbCptUpgButton.interactable = true;
        }
        else
        {
            _rmbCptUpgButton.interactable = false;
        }
    }

    private void UpgradeLMBClicker()
    {
        if (coinsScript.IsEnoughCoinsToBuy(storeScript.lmbUpgCost))
        {
            _lmbUpgrageButton.interactable = true;
        }
        else
        {
            _lmbUpgrageButton.interactable = false;
        }
    }

    private void BuyRobot()
    {
        if (coinsScript.IsEnoughCoinsToBuy(storeScript.robotCost))
        {
            _buyRobotButton.interactable = true;
        }
        else
        {
            _buyRobotButton.interactable = false;
        }
    }

    private void BuyRMB()
    {
        if (rmbClickerScript.isRMBBought || !coinsScript.IsEnoughCoinsToBuy(storeScript.rmbBuyCost))
        {
            _buyRmbButton.interactable = false;
        }
        else if (!rmbClickerScript.isRMBBought && coinsScript.IsEnoughCoinsToBuy(storeScript.rmbBuyCost))
        {
            _buyRmbButton.interactable = true;
        }
    }
}
