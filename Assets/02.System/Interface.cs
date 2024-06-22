using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;


delegate void OnPointerDownHandler(PointerEventData eventData);
public interface I_Click
{
    public void OnClick(PointerEventData eventData);
}
public interface I_Obsever
{
    public Action Func { get; set; }
    public Action<MoveButton> OnMoveButton { get; set; }
    //public Action<Inventory> OnInventory { get; set; }
    //public Action<JangBeSlot> OnJangBeSlot { get; set; }
    //public Action<OptionPanel> OnOptionPanel { get; set; }
}

public interface I_Publisher
{
    public void AddObsever(I_Obsever obsever);
    public void RemoveObsever(I_Obsever obsever);

    public void Notify();
    public void Notify(MoveButton moveButton);

    //public void Notify(Inventory inventory);
    //public void Notify(JangBeSlot jangBeSlot);
    //public void Notify(OptionPanel optionPanel);
}

public interface IVisit//구체화
{
    public void Visit(IVisitElement element);
}

public interface IVisitElement//넘겨주는 놈
{
    public void Accept(IVisit visitor);
}

public interface DrawProb
{
    public float ReProb();
    //public float Prob { get; set; }
}
