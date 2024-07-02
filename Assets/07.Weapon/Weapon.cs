using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int attackPower;
    public float ManualAttackTime;
    public float AutomaticAttackTime;
    protected float attackRange;

    public abstract void Attack();

    public abstract void SkillAttack();

    public void SetAttackPower(int value)
    {
        attackPower += value;
    }

    public void SetAttackRange(float attackRange)
    {
        this.attackRange = attackRange;
        Debug.Log(attackRange);
    }
}