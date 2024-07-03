using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBulletPattern : IPattern
{
    private int attackDamage;
    private GameObject bullet;
    private Transform bossTransform;
    private float attackDelay;
    public bool IsEndPattern { get; set; }

    public ThrowBulletPattern(int attackDamage, GameObject bullet, Transform bossTransform, float attackDelay)
    {
        this.attackDamage = attackDamage;
        this.bullet = bullet;
        this.bossTransform = bossTransform;
        this.attackDelay = attackDelay;
    }

    public void ExcutePattern()
    {
        float time = 0;
        while (time <= attackDelay)
        {
            time += Time.deltaTime;
        }
        ObjectPoolSystem.Instance.SpawnObject(bullet, bossTransform.position);
        IsEndPattern = true;
    }
}