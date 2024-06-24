using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitAttack : MonoBehaviour, IAttackable
{
    [SerializeField] protected int attackPower;
    [SerializeField] protected float attackDelayTime;
    [SerializeField] protected float currentAttackDelayTime;

    public void SetAttackPower(int damageValue)
    {
        attackPower = damageValue;
    }

    public abstract void Attack();

    public bool IsCanAttack()
    {
        return currentAttackDelayTime >= attackDelayTime;
    }
}
