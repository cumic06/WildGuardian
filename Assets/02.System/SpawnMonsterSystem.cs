using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsterSystem : MonoSingleton<SpawnMonsterSystem>
{
    [SerializeField] private SpawnMonsterData spawnMonsterData;
    [SerializeField] private float spawnTime;
    private float currentSpawnTime;

    private void Start()
    {
        UpdateSystem.Instance.AddFixedUpdateAction(SpawnSystem);
    }

    private void SpawnSystem()
    {
        currentSpawnTime += Time.deltaTime;

        if (IsCanSpawn())
        {
            currentSpawnTime = 0;
            Vector2 spawnPos = (Vector2)Player.Instance.transform.position;
            Debug.Log(spawnPos);
            SpawnMonster(spawnPos);
        }
    }

    public void SpawnMonster(Vector2 spawnPos)
    {
        int randomIndex = Random.Range(0, spawnMonsterData.spawnMonsterInfo.monsterList.Count);

        Instantiate(spawnMonsterData.spawnMonsterInfo.monsterList[randomIndex], spawnPos, Quaternion.identity);
    }

    private bool IsCanSpawn()
    {
        return currentSpawnTime >= spawnTime;
    }
}