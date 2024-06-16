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
    public Action<Inventory> Inventory { get; set; }
    public Action<JangBeSlot> JangBeSlot { get; set; }
    public Action<OptionPanel> OptionPanel { get; set; }
    public Action<MoveButton> MoveButton { get; set; }
}

public interface I_Publisher
{
    public void AddObsever(I_Obsever obsever);
    public void RemoveObsever(I_Obsever obsever);
    public void Notify(Inventory inventory);
    public void Notify(JangBeSlot jangBeSlot);
    public void Notify(OptionPanel optionPanel);
    public void Notify(MoveButton moveButton);
}

