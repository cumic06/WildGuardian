using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossPatternData", menuName = "Data/UnitData/PlayerData")]
public class BossPatternData : ScriptableObject
{
    public BossPatternInfo bossPatternInfo;
}

[Serializable]
public class BossPatternInfo
{
    public float moveSpeed;
}