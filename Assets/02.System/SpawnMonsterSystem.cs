using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsterSystem : MonoSingleton<SpawnMonsterSystem>
{
    [SerializeField] private SpawnMonsterData spawnMonsterData;

    public void SpawnMonster(Vector2 spawnPos)
    {
        int randomIndex = Random.Range(0, spawnMonsterData.spawnMonsterInfo.monsterList.Count);

        Instantiate(spawnMonsterData.spawnMonsterInfo.monsterList[randomIndex], spawnPos, Quaternion.identity);
    }
}
