using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DrawUI : MonoBehaviour, IVisitElement
{
    public Image EquipmentIMG;
    public Text Lank;

    public void Accept(IVisit visitor)
    {
        visitor.Visit(this);
    }

    public void Start()
    {
    }

    public void UISet(string lank, Sprite equipment)
    {
        transform.GetChild(0).gameObject.SetActive(true);
        EquipmentIMG.sprite = equipment;
        Lank.text = lank;
    }
}
