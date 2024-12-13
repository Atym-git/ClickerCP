using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class IsCursorOnABitcoin : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isCursorOnABitcoin;

    public void OnPointerEnter(PointerEventData pointerEventData) =>
        isCursorOnABitcoin = true;

    public void OnPointerExit(PointerEventData pointerEventData) =>
        isCursorOnABitcoin = false;
}
