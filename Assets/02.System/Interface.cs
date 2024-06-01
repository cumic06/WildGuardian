using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;



public interface I_Click
{
    public void OnClick(PointerEventData eventData);
}
public interface I_Obsever
{
    public Delegate Func { get; set; }
}

public interface I_Publisher
{
    public void AddObsever(I_Obsever obsever);
    public void RemoveObsever(I_Obsever obsever);
    public void Notify();
}

