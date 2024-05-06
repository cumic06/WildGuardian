using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObseverFunc : I_Obsever
{
    public Action<object> Obsever = (a) => { };
    public void Func<T>(T t)
    {
        Obsever(t);
    }
}
