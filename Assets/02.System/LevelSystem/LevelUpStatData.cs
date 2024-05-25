using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "LevelUpStatData", menuName = "LevelUpStatData")]
public class LevelUpStatData : ScriptableObject
{
    public List<LevelUpStatInfo> LevelUpStatInfo = new();

    public float GetRandomLevelUpStat(out Sprite sprite)
    {
        int randomValue = UnityEngine.Random.Range(0, Enum.GetValues(typeof(LevelUpStat)).Length);
        sprite = LevelUpStatInfo[randomValue].sprite;
        return LevelUpStatInfo[randomValue].StatValue;
    }
}

[Serializable]
public class LevelUpStatInfo
{
    public LevelUpStat LevelUpStat;

    public float StatValue;

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