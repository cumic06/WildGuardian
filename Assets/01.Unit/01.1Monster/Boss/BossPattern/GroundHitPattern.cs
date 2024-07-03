using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHitPattern : IPattern
{
    private Transform bossTransform;
    private float attackRange;
    private int attackDamage;
    private float attackDelay;
    public bool IsEndPattern { get; set; }

    public GroundHitPattern(Transform bossTransform, float attackRange, int attackDamage, float attackDelay)
    {
        this.bossTransform = bossTransform;
        this.attackRange = attackRange;
        this.attackDamage = attackDamage;
        this.attackDelay = attackDelay;
    }


    public void ExcutePattern()
    {
        float time = 0;
        while (time <= attackDelay)
        {
            time += Time.deltaTime;
        }
        GroundHit();
    }

    private void GroundHit()
    {
        Collider2D playerCheck = Physics2D.OverlapCircle(bossTransform.position, attackRange);

        if (playerCheck == null) return;

        playerCheck.TryGetComponent(out Player player);
        HpManager.Instance.TakeDamage(player, attackDamage);
    }
}
