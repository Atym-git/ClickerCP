using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IsCursorOnABitcoin : MonoBehaviour
{
    public bool isCursorOnABitcoin;

    private void OnMouseEnter() => isCursorOnABitcoin = true;

    private void OnMouseExit() => isCursorOnABitcoin = false;
}