using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

[CreateAssetMenu(fileName = "DrawMachine", menuName = "Data/DrawData")]

public class DrawData : Data
{
    public DrawInfo[] DrawInfos;
#if UNITY_EDITOR
    public float SumProb;
    public void OnValidate()
    {
        if (DrawInfos == null)
        {
            return;
        }
        DrawInfos = DrawInfos.OrderByDescending(prob => prob.Prob).ToArray();

        SumProb = 0;
        foreach (var grade in DrawInfos)
        {
            SumProb += grade.Prob;
        }
        if (SumProb > 1)
        {
            Debug.LogError("over Range");
        }
    }
#endif
}

[Serializable]
public class DrawInfo : DrawProb
{
    public EquipmentRank EquipmentRank;
    public float Prob;
    public float ReProb()
    {
        return Prob;
    }
}

