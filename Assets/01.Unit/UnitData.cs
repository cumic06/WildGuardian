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

    public UnitStat GetUnitStat()
    {
        return unitStat;
    }

    public string GetName()
    {
        return unitName;
    }

    public void SumUnitData(UnitStat stat)
    {
        unitStat.maxHp += stat.maxHp;
        unitStat.moveSpeed += stat.moveSpeed;
        unitStat.defensePower += stat.defensePower;
        unitStat.attackRange += stat.attackRange;
        unitStat.attackPower += stat.attackPower;
    }
    public void MinusUnitData(UnitStat stat)
    {
        unitStat.maxHp -= stat.maxHp;
        unitStat.moveSpeed -= stat.moveSpeed;
        unitStat.defensePower -= stat.defensePower;
        unitStat.attackRange -= stat.attackRange;
        unitStat.attackPower -= stat.attackPower;
    }
}

[Serializable]
public struct UnitStat
{
    public int maxHp;
    public float moveSpeed;
    public int defensePower;
    public float attackRange;
    public int attackPower;
}