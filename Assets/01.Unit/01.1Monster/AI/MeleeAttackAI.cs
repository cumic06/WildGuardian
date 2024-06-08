using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackAI : MonsterAI
{
    public override void Attack()
    {
        if (IsCanAttackRange(out Collider2D[] players))
        {
            foreach (var check in players)
            {
                if (check.TryGetComponent(out IDamageable player))
                {
                    HpManager.Instance.TakeDamage(player, monster.GetUnitData().GetUnitStat().attackPower);
                }
            }
        }
    }
}
