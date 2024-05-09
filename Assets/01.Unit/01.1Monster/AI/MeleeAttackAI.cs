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
                check.TryGetComponent(out Player player);
                player.TakeDamage(monster.GetUnitType(), monster.GetUnitData().GetUnitStat().attackPower);
            }
        }
    }
}
