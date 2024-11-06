using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MainClicker))]
public class RMBClicker : MonoBehaviour
{
    [SerializeField] private int startingRMBPower; // How much you get insantly after you press RMB button
    private int currentRMBPower;
    private float timeEachTick = 0.03f; // Each time you get an extra RMBPower / Overall time divided by 100
    [SerializeField] private int startingpowerMultiplayer = 3;
    private int currentpowerMultiplayer = 3; // How more is max power compared to min power

    [SerializeField] private Camera MainCamera;
    [SerializeField] private Image bitcoinPlacement;

    MainClicker mainClicker;

    Vector2 mousePosition;

    private void Start()
    {
        mainClicker = FindFirstObjectByType<MainClicker>();
        mousePosition = Input.mousePosition;

        currentRMBPower = startingRMBPower;
        currentpowerMultiplayer = startingpowerMultiplayer;
    }

    private void Update()
    {
        RMBButtonDown();
        RMBButtonUp();
    }


    private void RMBButtonDown()
    {
        Ray cursorTrackerRay = MainCamera.ScreenPointToRay(mousePosition);
        RaycastHit hitAnything; // Not exactly the bitcoin

        bool weHitSomething = Physics.Raycast(cursorTrackerRay, out hitAnything);

        if (Input.GetMouseButtonDown(1) && weHitSomething && hitAnything.transform.GetComponent<BoxCollider2D>())
        {
        StartCoroutine(DelayBetweenAddingPower());
        }
    }

    private void RMBButtonUp()
    {
        if (Input.GetMouseButtonUp(1))
        {
            mainClicker.amountOfCoins += currentRMBPower;
            currentRMBPower = startingRMBPower;
        }
    }

    private IEnumerator DelayBetweenAddingPower()
    {
        while (currentRMBPower <= startingRMBPower * currentpowerMultiplayer)
        {
            currentRMBPower++;
            yield return new WaitForSeconds(timeEachTick);
        }
    }


}
