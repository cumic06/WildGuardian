using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarAttackAI : MonsterAI
{
    #region veriable
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform bulletPos;
    #endregion

    public override void Attack()
    {
        if (IsCanAttackRange(out Collider2D[] players))
        {
            GameObject spawnBullet = Instantiate(bullet.gameObject);
            spawnBullet.GetComponent<Bullet>().SetAttackPower(monster.GetUnitData().GetUnitStat().attackPower);

            if (bulletPos != null)
            {
                //#if UNITY_EDITOR
                //                Debug.Log("BulletPos");
                //#endif
                spawnBullet.transform.position = bulletPos.position;
            }
            spawnBullet.transform.position = transform.position;
            //#if UNITY_EDITOR
            //            Debug.Log("BulletPosNull");
            //#endif
        }
    }
}