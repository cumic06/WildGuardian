using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    public Transform halfCircleCenter;

    public override void Attack()
    {
        Collider2D monsters = Physics2D.OverlapCircleAll(transform.position, attackRange, LayerMaskManager.monsterLayer).FirstOrDefault();

        if (monsters == null) return;

        if (monsters.TryGetComponent(out IDamageable monster))
        {
            HpManager.Instance.TakeDamage(monster, attackPower);
            Debug.Log("Sword");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public override void SkillAttack()
    {
        Collider2D monsters = Physics2D.OverlapCircleAll(transform.position, attackRange * 2, LayerMaskManager.monsterLayer).FirstOrDefault();

        if (monsters == null) return;

        if (monsters.TryGetComponent(out IDamageable monster))
        {
            HpManager.Instance.TakeDamage(monster, attackPower);
        }
        Debug.Log("SwordSkill");
    }
}
