using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Unit
{
    #region variable
    protected MonsterAI monsterAI;

    public float AttackRange => GetUnitData().GetUnitStat().attackRange;

    [SerializeField] protected LayerMask playerLayer;
    public LayerMask PlayerLayer => playerLayer;

    public float currentAttackCoolTime;
    #endregion

    protected override void Awake()
    {
        base.Awake();
        monsterAI = GetComponent<MonsterAI>();
    }

    protected override void Start()
    {
        base.Start();
        UpdateSystem.Instance.AddFixedUpdateAction(() => monsterAI.AI());
    }


    public override void ChangeHp(int value)
    {

    }

    public override void OnDead()
    {
        UpdateSystem.Instance.RemoveFixedUpdateAction(() => monsterAI.AI());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable unit))
        {
            HpManager.Instance.TakeDamage(unit, GetUnitData().GetUnitStat().attackPower);
        }
    }

}