using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarMonsterAttack : MonsterAttack
{
    public Bullet bullet;
    public Transform bulletPos;

    public override void Attack()
    {
        base.Attack();

        Bullet spawnBullet = Instantiate(bullet);

        if (bulletPos == null)
        {
            spawnBullet.transform.position = transform.position;
        }
        else
        {
            spawnBullet.transform.position = bulletPos.position;
        }
        Vector2 dir = Player.Instance.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        spawnBullet.transform.eulerAngles = new Vector3(0, 0, angle);
    }
}