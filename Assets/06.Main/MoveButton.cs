using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveButton : MonoBehaviour, IPointerClickHandler
{
    public int MoveIndex;
    public static ObseverManager MovePanel_Obsever = new();
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        MovePanel_Obsever.Notify(this);
        Debug.Log("ÅÍÄ¡");
    }
}
