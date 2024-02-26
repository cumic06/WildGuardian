using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    public static Player Instance;

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }
}
