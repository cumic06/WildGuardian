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
    public void Notify<T>(T t)
    {
        Debug.Log(t);
        obseverList.ForEach(x => x.Func(t));
    }
}
