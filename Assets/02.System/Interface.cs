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
    //delegate void Func<T>(T t);
    //public void Func<U>(U t);
}

public interface I_Publisher
{
    public void AddObsever(I_Obsever obsever);
    public void RemoveObsever(I_Obsever obsever);
    public void Notify<T>(T t);
}

