using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MainClicker))]
public class AutoClicksPerSecond : MonoBehaviour
{
    public int amountOfCPS; //CPS = ClicksPerSecond
    [SerializeField] private Button hireARobotButton;
    private int amountOfRobots;
    MainClicker mainClicker;

    private void Start()
    {
        hireARobotButton.onClick.AddListener(HireARobot);
        mainClicker = GetComponent<MainClicker>();
    }

    private void HireARobot() => amountOfRobots++;

    private void Update()
    {
        StartCoroutine(GetCPS());
    }

    IEnumerator GetCPS()
    {
        if (amountOfRobots >= 1)
        {
        mainClicker.amountOfCoins += amountOfCPS;
        yield return new WaitForSeconds(1f);
        }
    }


}
