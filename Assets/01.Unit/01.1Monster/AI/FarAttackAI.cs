using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarAttackAI : MonsterAI
{
    #region veriable
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform bulletPos;
    [SerializeField] private int bulletCount;
    [SerializeField] private int bulletAngle;
    #endregion

    public override void Attack()
    {
        if (IsCanAttackRange(out Collider2D[] players))
        {
            SpawnBullet();
        }
    }

    private void SpawnBullet()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject spawnBullet = Instantiate(bullet.gameObject);
            spawnBullet.GetComponent<Bullet>().SetAttackPower(monster.GetUnitData().GetUnitStat().attackPower);

            Vector3 bulletRotation = new(0, 0, GetBulletAngle() - (bulletAngle * i));
            if (bulletPos != null)
            {
                //#if UNITY_EDITOR
                //                Debug.Log("BulletPos");
                //#endif
                spawnBullet.transform.position = bulletPos.position;
                spawnBullet.transform.eulerAngles = bulletRotation;
            }
            spawnBullet.transform.position = transform.position;
            spawnBullet.transform.eulerAngles = bulletRotation;
            //#if UNITY_EDITOR
            //            Debug.Log("BulletPosNull");
            //#endif
        }
    }

    private float GetBulletAngle()
    {
        Vector2 dir = Player.Instance.transform.position - transform.position;
        dir.Normalize();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        float resultAngle = bulletCount * bulletAngle * 0.5f + angle - 10;
        return resultAngle;
    }
}