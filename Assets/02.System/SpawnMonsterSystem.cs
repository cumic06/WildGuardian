using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsterSystem : MonoSingleton<SpawnMonsterSystem>
{
    [SerializeField] private SpawnMonsterData spawnMonsterData;
    [SerializeField] private float spawnTime;
    [SerializeField] private bool noSpawnMonster;

    private bool isBossSpawn;
    private float currentSpawnTime;

    private const float spawnRange = 20;

    private void Start()
    {
        UpdateSystem.Instance.AddFixedUpdateAction(SpawnSystem);
    }

    private void SpawnSystem()
    {
        currentSpawnTime += Time.deltaTime;

        if (IsBossCanBossSpawn())
        {
            Vector2 spawnPos = (Vector2)Player.Instance.transform.position + Random.insideUnitCircle * spawnRange;
            SpawnBoss(spawnPos);

            isBossSpawn = true;
            return;
        }

        if (IsCanSpawn() && !noSpawnMonster)
        {
            currentSpawnTime = 0;

            Vector2 spawnPos = (Vector2)Player.Instance.transform.position + Random.insideUnitCircle * spawnRange;

            //Debug.Log(spawnPos);
            SpawnMonster(spawnPos);
        }
    }

    public void SpawnMonster(Vector2 spawnPos)
    {
        int randomIndex = Random.Range(0, spawnMonsterData.spawnMonsterInfo.monsterList.Count);
        GameObject spawnMonster = Instantiate(spawnMonsterData.spawnMonsterInfo.monsterList[randomIndex], spawnPos, Quaternion.identity);
        spawnMonster.transform.SetParent(transform);
    }

    public void SpawnBoss(Vector2 spawnPos)
    {
        int randomIndex = Random.Range(0, spawnMonsterData.spawnMonsterInfo.bossList.Count);
        GameObject spawnBoss = Instantiate(spawnMonsterData.spawnMonsterInfo.bossList[randomIndex], spawnPos, Quaternion.identity);
        spawnBoss.transform.SetParent(transform);
    }

    private bool IsCanSpawn()
    {
        return currentSpawnTime >= spawnTime;
    }

    private bool IsBossCanBossSpawn()
    {
        return TimeManager.Instance.GetInGameTimeMin() % 2 == 0 && TimeManager.Instance.GetInGameTimeMin() > 1 && !isBossSpawn;
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(Player.Instance.transform.position, spawnRange);
        }
    }
}