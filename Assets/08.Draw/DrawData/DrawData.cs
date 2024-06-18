using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DrawMachine", menuName = "Data/DrawData")]

public class DrawData : Data
{
    public DrawInfo[] DrawInfos;

}

[Serializable]
public class DrawInfo
{
    public EquipmentRank equipmentType;
    public float Prob;
    public DrawEquipmentInfo[] DrawEquipmentInfos;
}
[Serializable]
public class DrawEquipmentInfo
{
    public Sprite Equipment_Img;
    public float Prob;
}
