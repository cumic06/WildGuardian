using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "EquipmentData", menuName = "Data/EquipmentData")]

public class EquipmentData : Data
{
    public EquipmentInfo[] EquipmentInfo;
    public Dictionary<Sprite, EquipmentInfo> EquipmentInfoData = new Dictionary<Sprite, EquipmentInfo>();
    public void EquipmentInfoDataSet()
    {
        foreach (EquipmentInfo info in EquipmentInfo)
        {
            EquipmentInfoData.Add(info.GetUnitType(), info);
        }
    }

   
}
[Serializable]
public class EquipmentInfo
{
    [SerializeField] private string equipmentName;
    [SerializeField][TextArea] private string equipmentExplain;
    [SerializeField] private EquipmentType equipmentType;
    [SerializeField] private EquipmentRank equipmentRank;
    [SerializeField] private Sprite equipmentImage;
    [SerializeField] private UnitStat unitStat;
    /*[HideInInspector] */public bool Check = true;


    public UnitStat GetUnitStat() => unitStat;

    public EquipmentType GetEquipmentType() => equipmentType;

    public EquipmentRank GetEquipmentRank() => equipmentRank;

    public Sprite GetUnitType() => equipmentImage;

    public string GetName() => equipmentName;
    public string GetExplain() => equipmentExplain;
}

public enum EquipmentType
{
    Armor,
    Weapon,
    Ring,
    Ring2
}

public enum EquipmentRank
{
    R,
    SR,
    SSR,
    UR,
    LR
}

public enum WeaponType
{
    MeleeEquipment,
    RangedEquipment
}