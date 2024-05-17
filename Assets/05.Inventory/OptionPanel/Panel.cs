using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Panel : MonoBehaviour, I_Click
{
    public void OnClick(PointerEventData eventData)
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
