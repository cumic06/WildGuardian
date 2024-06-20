using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DrawResult", menuName = "Data/ DrawResultData")]
public class DrawResultData : Data
{
    public Queue<Result> ResultInfo = new();
}

[Serializable]
public struct Result
{
    public EquipmentRank equipmentType;
    public Sprite Equipment_Img;

    public Result(EquipmentRank equipmentType, Sprite equipment_Img)
    {
        this.equipmentType = equipmentType;
        Equipment_Img = equipment_Img;
    }
}
