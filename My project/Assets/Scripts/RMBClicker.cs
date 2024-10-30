using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MainClicker))]
public class RMBClicker : MonoBehaviour
{
    [SerializeField] private int startingRMBPower; // How much you get insantly after you press RMB button
    private int currentRMBPower;
    private float timeEachTick = 0.03f; // Each time you get an extra RMBPower / 100
    
    [SerializeField] private Camera MainCamera;
    [SerializeField] private Image bitcoinPlacement;

    MainClicker mainClicker;

    Vector2 mousePosition = Input.mousePosition;

    private void Start()
    {
        currentRMBPower = startingRMBPower;
        mainClicker = GetComponent<MainClicker>();
    }

    private void Update()
    {
        CheckRayCastHit();
        RMBButtonDown();
        RMBButtonUp();
    }

    private void CheckRayCastHit()
    {
        Ray cursorTrackerRay = MainCamera.ScreenPointToRay(mousePosition);
        RaycastHit hitAnything; // Not exactly the bitcoin

        bool weHitSomething = Physics.Raycast(cursorTrackerRay, out hitAnything);
    }
    private void RMBButtonDown()
    {
        if (Input.GetMouseButtonDown(1))
        {
        StartCoroutine(DelayBetweenAddingPower());
        }
    }

    private IEnumerator DelayBetweenAddingPower()
    {
        while (currentRMBPower <= startingRMBPower * 3)
        {
            currentRMBPower++;
            yield return new WaitForSeconds(timeEachTick);
        }
    }

    private void RMBButtonUp()
    { 
    if (Input.GetMouseButtonUp(1))
        {
            mainClicker.amountOfClicks += currentRMBPower;
            currentRMBPower = startingRMBPower;
        }
    }


}
