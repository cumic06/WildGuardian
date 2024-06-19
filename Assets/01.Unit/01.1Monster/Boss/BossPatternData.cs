using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossPatternData", menuName = "Data/UnitData/BossPatternData")]
public class BossPatternData : ScriptableObject
{
    public List<BossPatternInfo> bossPatternInfo;
}

[Serializable]
public class BossPatternInfo
{
    public int attackPower;
    public float attackDelayTime;
    public float readyDelayTime;
    public float moveSpeed;
    public float detectRange;
}