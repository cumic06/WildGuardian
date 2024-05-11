using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackAI : MonsterAI
{
    public override void Attack()
    {
        Collider2D[] checkCircle = Physics2D.OverlapCircleAll(transform.position, monster.AttackRange, monster.PlayerLayer);
        if (checkCircle.Length > 0)
        {
            foreach (var check in checkCircle)
            {
                if (check.TryGetComponent(out IDamageable player))
                {
                    HpManager.Instance.TakeDamage(player, monster.GetUnitData().GetUnitStat().attackPower);
                }
            }
        }
    }
}
