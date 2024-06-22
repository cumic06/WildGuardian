using System;
using System.Linq;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "EquipmentData", menuName = "Data/EquipmentData")]

public class EquipmentData : Data
{
    public EquipmentInfo[] EquipmentInfo;
    public Dictionary<Sprite, EquipmentInfoInternal> EquipmentInfoData = new Dictionary<Sprite, EquipmentInfoInternal>();
    public void OnValidate()
    {
        foreach (var equip in EquipmentInfo)
        {
            equip.OnValidate();
        }
    }
    public void EquipmentInfoDataSet()
    {
        foreach (EquipmentInfo info in EquipmentInfo)
        {
            foreach (EquipmentInfoInternal equipinternal in info.EquipmentInfoInternal)
            {
                EquipmentInfoData.Add(equipinternal.EquipmentImage, equipinternal);
            }
        }
    }
}
[Serializable]
public class EquipmentInfo
{
    public EquipmentRank EquipmentRank;
    public EquipmentInfoInternal[] EquipmentInfoInternal;
#if UNITY_EDITOR
    public float SumProb;
    public void OnValidate()
    {
        if (EquipmentInfoInternal == null)
        {
            return;
        }
        EquipmentInfoInternal = EquipmentInfoInternal.OrderByDescending(prob => prob.Prob).ToArray();

        SumProb = 0;
        foreach (var grade in EquipmentInfoInternal)
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
public class EquipmentInfoInternal : DrawProb
{
    public string EquipmentName;
    [TextArea] public string EquipmentExplain;
    public EquipmentType EquipmentType;
    public Sprite EquipmentImage;
    public UnitStat UnitStat;
    public float Prob;

    public float ReProb()
    {
        return Prob;
    }
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
