using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObseverFunc : MonoBehaviour, I_Obsever
{

    //}
    //public Action<Inventory> Inventory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //public Action<JangBeSlot> JangBeSlot { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //public Action<OptionPanel> OptionPanel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //public Action<MoveButton> MoveButton { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //public Action<Inventory> OnInventory { get; set; }
    //public Action<JangBeSlot> OnJangBeSlot { get; set; }
    //public Action<OptionPanel> OnOptionPanel { get; set; }
    public Action Func { get; set; }
    public Action<MoveButton> OnMoveButton { get; set; }
}
//public class MoveButtonFunc : I_Obsever
//{

//}

