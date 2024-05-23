using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExpType
{
    LowExp,
    MiddleExp,
    HighExp
}

public class LevelSystem : MonoSingleton<LevelSystem>
{
    #region veriable
    private const float levelUpValue = 1.4f;
    [SerializeField] private float maxExp;
    [SerializeField] private float currentExp;
    [SerializeField] private int level;
    [SerializeField] private GameObject[] expPrefab;
    #endregion

    public void AddExp(int value)
    {
        currentExp += value;

        int levelUpCount = (int)(currentExp / maxExp);
        for (int i = 0; i < levelUpCount; i++)
        {
            if (currentExp >= maxExp)
            {
                currentExp -= maxExp;
                LevelUp(1);
            }
        }
    }

    private void LevelUp(int value)
    {
        level += value;
        maxExp *= levelUpValue;
    }

    public void SpawnExp(Vector2 pos, ExpType expType)
    {
        Vector2 spawnPos = pos * Random.insideUnitCircle;
#if UNITY_EDITOR
        Debug.Log("SpawnExp");
#endif
        switch (expType)
        {
            case ExpType.LowExp:
                Instantiate(expPrefab[0], spawnPos, Quaternion.identity);
                break;
            case ExpType.MiddleExp:
                Instantiate(expPrefab[1], spawnPos, Quaternion.identity);
                break;
            case ExpType.HighExp:
                Instantiate(expPrefab[2], spawnPos, Quaternion.identity);
                break;
        }
    }
}
