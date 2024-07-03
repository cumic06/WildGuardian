using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchPattern : IPattern
{
    private int scratchCount;

    public ScratchPattern(int scratchCount)
    {
        this.scratchCount = scratchCount;
    }

    public bool IsEndPattern { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void ExcutePattern()
    {
        for (int i = 0; i < scratchCount; i++)
        {
            Debug.Log("Scratch");
        }
    }
}
