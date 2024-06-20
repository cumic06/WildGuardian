using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObseverManager : I_Publisher
{
    public List<I_Obsever> obseverList = new();


    public void AddObsever(I_Obsever obsever)
    {
        obseverList.Add(obsever);
    }
    public void RemoveObsever(I_Obsever obsever)
    {
        obseverList.Remove(obsever);
    }
    public void Notify()
    {
        obseverList?.ForEach(obsever => { obsever.Func(); });
    }
    public void Notify(MoveButton moveButton)
    {
        obseverList?.ForEach(obsever => { obsever.OnMoveButton(moveButton); });
    }











    //public void Notify(Inventory inventory)
    //{
    //    obseverList?.ForEach(obsever => { obsever.OnInventory(inventory); });
    //}

    //public void Notify(JangBeSlot jangBeSlot)
    //{
    //    obseverList?.ForEach(obsever => { obsever.OnJangBeSlot(jangBeSlot); });
    //    //throw new System.NotImplementedException();
    //}

    //public void Notify(OptionPanel optionPanel)
    //{
    //    obseverList?.ForEach(obsever => { obsever.OnOptionPanel(optionPanel); });
    //}


}
