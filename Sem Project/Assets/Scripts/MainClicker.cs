using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainClicker : MonoBehaviour
{
    public int amountOfClicks;

    [SerializeField] public Image bitcoinPlacement;
    [SerializeField] private Camera MainCamera;

    private void Update()
    {
        BitcoinLMBClick();
    }

    private void BitcoinLMBClick()
    {
        Vector2 mousePosition = Input.mousePosition;

        Ray cursorTrackerRay = MainCamera.ScreenPointToRay(mousePosition);
        RaycastHit hitAnything; // Not exactly the bitcoin
        
        bool weHitSomething = Physics.Raycast(cursorTrackerRay, out hitAnything);

        if (Input.GetMouseButtonDown(0) && weHitSomething && hitAnything.transform.GetComponent<BoxCollider2D>())
        {
            amountOfClicks++;
        }

    }

}
