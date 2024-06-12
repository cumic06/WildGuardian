using System;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "Data/UnitData/UnitData", order = 0)]
public class UnitData : Data
{
    public UnitInfo unitInfo;
}

[Serializable]
public class UnitInfo
{
    [SerializeField] private string unitName;
    public UnitStat unitStat;

    public UnitStat GetUnitStat()
    {
        return unitStat;
    }

    public string GetName()
    {
        return unitName;
    }

    public void SumUnitStat(UnitStat stat)
    {
        unitStat.maxHp += stat.maxHp;
        unitStat.hp += stat.maxHp;
        unitStat.moveSpeed += stat.moveSpeed;
        unitStat.defensePower += stat.defensePower;
        unitStat.attackRange += stat.attackRange;
        unitStat.attackPower += stat.attackPower;
        unitStat.attackDelayTime += stat.attackDelayTime;
    }

    public void MinusUnitStat(UnitStat stat)
    {
        unitStat.maxHp -= stat.maxHp;
        unitStat.hp -= stat.hp;
        unitStat.moveSpeed -= stat.moveSpeed;
        unitStat.defensePower -= stat.defensePower;
        unitStat.attackRange -= stat.attackRange;
        unitStat.attackPower -= stat.attackPower;
        unitStat.attackDelayTime -= stat.attackDelayTime;
    }
}

[Serializable]
public struct UnitStat
{
    public int maxHp;
    public int hp;
    public float moveSpeed;
    public int defensePower;
    public float attackRange;
    public int attackPower;
    public float attackDelayTime;
}