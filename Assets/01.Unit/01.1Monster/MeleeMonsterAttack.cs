using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeMonsterAttack : MonsterAttack
{
    public float attackRadius;
    public override void Attack()
    {
        base.Attack();
        Collider2D player = Physics2D.OverlapCircleAll(transform.position, attackRadius, LayerMaskManager.playerLayer).FirstOrDefault();

        if (player == null) return;
        Debug.Log(player.name);

        if (player.TryGetComponent(out IDamageable monster))
        {
            HpManager.Instance.TakeDamage(monster, attackPower);
        }
    }
}