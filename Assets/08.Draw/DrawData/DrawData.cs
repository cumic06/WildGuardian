using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DrawMachine", menuName = "Data/DrawData")]

public class DrawData : Data
{
    public DrawInfo[] DrawInfos;

}


[CreateAssetMenu(fileName = "DrawChild", menuName = "Data/DrawChildData")]

public class DrawChildData : Data
{
    public DrawEquipmentInfo[] DrawEquipmentInfos;

}
[Serializable]
public class DrawInfo
{
    public EquipmentRank equipmentType;
    public float Prob;
}
[Serializable]
public class DrawEquipmentInfo
{
    public Sprite Equipment_Img;
    public float Prob;
}
