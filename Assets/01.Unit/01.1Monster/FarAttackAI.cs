using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarAttackAI : MonsterAI
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform bulletPos;

    public override void Attack()
    {
        Collider2D[] playerCheckCircle = Physics2D.OverlapCircleAll(transform.position, monster.AttackRange, monster.PlayerLayer);
        if (playerCheckCircle.Length > 0)
        {
            GameObject spawnBullet = Instantiate(bullet.gameObject);
            spawnBullet.GetComponent<Bullet>().SetAttackPower(monster.GetUnitData().GetUnitStat().attackPower);

            if (bulletPos != null)
            {
                Debug.Log("BulletPos");
                spawnBullet.transform.position = bulletPos.position;
            }
            spawnBullet.transform.position = transform.position;
            Debug.Log("BulletPosNull");
        }
    }
}