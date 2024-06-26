using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitAttack : MonoBehaviour, IAttackable
{
    protected int attackPower;
    /*[SerializeField] */protected float attackDelayTime;
    public float currentAttackDelayTime;
    /*[SerializeField] */protected float attackRange;

    public void SetAttackPower(int attackPowerValue)
    {
        attackPower = attackPowerValue;
    }

    public void SetAttackDelayTime(float attackDelayTime)
    {
        this.attackDelayTime = attackDelayTime;
    }

    public void SetAttackRange(float attackRange)
    {
        this.attackRange = attackRange;
    }

    public abstract void Attack();

    public bool IsCanAttack()
    {
        return currentAttackDelayTime >= attackDelayTime;
    }
}
