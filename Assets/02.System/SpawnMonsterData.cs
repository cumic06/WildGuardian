using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "SpawnMonsterData", menuName = "SpawnMonsterData")]
public class SpawnMonsterData : ScriptableObject
{
    public SpawnMonsterInfo spawnMonsterInfo;
}

[Serializable]
public class SpawnMonsterInfo
{
    public List<GameObject> monsterList;
}