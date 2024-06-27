using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarMonsterAttack : MonsterAttack
{
    public Bullet bullet;
    public Transform bulletPos;

    public int bulletCount;
    public float bulletAngle;

    public override void Attack()
    {
        base.Attack();

        for (int i = 0; i < bulletCount; i++)
        {
            Bullet spawnBullet = Instantiate(bullet);

            if (bulletPos == null)
            {
                spawnBullet.transform.position = transform.position;
            }
            else
            {
                spawnBullet.transform.position = bulletPos.position;
            }
            Vector3 bulletRotation = new(0, 0, GetBulletAngle() - bulletAngle * i);
            spawnBullet.transform.eulerAngles = bulletRotation;
        }
    }

    private float GetBulletAngle()
    {
        Vector2 dir = Player.Instance.transform.position - transform.position;
        dir.Normalize();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        float resultAngle = bulletCount * bulletAngle * 0.5f + angle;
        return resultAngle;
    }
}