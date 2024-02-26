using System;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitStat", menuName = "UnitStat", order = 0)]
public class UnitData : ScriptableObject
{
    public UnitInfo unitInfo;
}

[Serializable]
public class UnitInfo
{
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
}

[Serializable]
public struct UnitStat
{
    public int maxHp;
    public float moveSpeed;
    public float defensePower;
    public float attackRange;
}

public enum UnitType
{
    Player,
    Enemy
}
