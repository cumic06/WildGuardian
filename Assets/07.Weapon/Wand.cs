using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : Weapon
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform bulletPos;

    public override void Attack()
    {
        Collider2D monsters = Physics2D.OverlapCircleAll(transform.position, attackRange * 2, LayerMaskManager.monsterLayer).FirstOrDefault();

        if (monsters == null) return;

        monsters.TryGetComponent(out Monster monster);

        Debug.Log("monster");

        Bullet spawnBullet = Instantiate(bullet);
        if (bulletPos == null)
        {
            spawnBullet.transform.position = transform.position;
        }
        else
        {
            spawnBullet.transform.position = bulletPos.position;
        }

        Vector3 dir = monster.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        spawnBullet.transform.eulerAngles = new Vector3(0, 0, angle);
    }

    public override void SkillAttack()
    {
        Debug.Log("WandSkill");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange * 2);
    }
}
