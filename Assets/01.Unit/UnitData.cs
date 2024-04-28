using System;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "Data/UnitData", order = 0)]
public class UnitData : Data
{
    public UnitInfo unitInfo;
}

[Serializable]
public class UnitInfo
{
    [SerializeField] private string unitName;
    [SerializeField] private UnitStat unitStat;
    [SerializeField] private UnitType unitType;

    public UnitStat GetUnitStat()
    {
        return unitStat;
    }

    public UnitType GetUnitType()
    {
        return unitType;
    }

    public string GetName()
    {
        return unitName;
    }
}

[Serializable]
public struct UnitStat
{
    public int maxHp;
    public float moveSpeed;
    public float defensePower;
    public float attackRange;
    public int attackPower;
}

public enum UnitType
{
    Player,
    Monster
}
