using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JangBeSlot : MonoBehaviour, IPointerClickHandler
{
    public int slotIndex;
    public static ObseverManager MovePanel_Obsever = new();
    public void OnPointerClick(PointerEventData eventData)
    {

    }
}
