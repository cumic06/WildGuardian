using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;


[CreateAssetMenu(fileName = "LevelUpStatData", menuName = "LevelUpStatData")]
public class LevelUpStatData : ScriptableObject
{
    public List<LevelUpStatInfo> LevelUpStatInfo = new();
    public LevelUpStatInfo GetRandomLevelUpStat()
    {
        int randomValue = Random.Range(0, LevelUpStatInfo.Count);
        return LevelUpStatInfo[randomValue];
    }
}

[Serializable]
public class LevelUpStatInfo
{
    public string name;

    public LevelUpStat LevelUpStatType;

    public string explan;

    public float StatValue;

    public UnitStat LevelUpStats;

    public Sprite sprite;
}
public enum LevelUpStat
{
    HpStat,
    ManaStat,
    AttackPowerStat,
    AttackCoolTimeStat,
    DefensePowerStat,
    HealHpStat,
    HealManaStat
}