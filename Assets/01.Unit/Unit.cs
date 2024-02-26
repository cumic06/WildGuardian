using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IDamageable
{
    public void TakeDamage(UnitType unitType, int damage);
}

[RequireComponent(typeof(Rigidbody2D))]
public class Unit : MonoBehaviour, IDamageable
{
    [SerializeField] protected UnitData unitData;

    [SerializeField] protected int currentHp = 0;
    public int CurrentHp => currentHp;

    [SerializeField] protected float currentMoveSpeed = 0;
    public float CurrentMoveSpeed => currentMoveSpeed;

    [SerializeField] protected float currentDefensePower = 0;
    public float CurrentDefensePower => currentDefensePower;

    [SerializeField] protected float currentAttackRange = 0;
    public float CurrentAttackRange => currentAttackRange;


    protected virtual void Awake()
    {
        ResetAll();
    }

    #region Reset
    protected void ResetAll()
    {
        ResetHp();
        ResetMoveSpeed();
        ResetDefesePower();
        ResetAttackRange();
    }

    protected void ResetHp()
    {
        currentHp = unitData.unitInfo.GetUnitStat().maxHp;
    }
    protected void ResetMoveSpeed()
    {
        currentMoveSpeed = unitData.unitInfo.GetUnitStat().moveSpeed;
    }
    protected void ResetDefesePower()
    {
        currentDefensePower = unitData.unitInfo.GetUnitStat().defensePower;
    }
    protected void ResetAttackRange()
    {
        currentAttackRange = unitData.unitInfo.GetUnitStat().attackRange;
    }
    #endregion

    #region Hp
    public void TakeDamage(UnitType unitType, int damage)
    {
        if (!EqualsUnitType(unitType))
        {
            if (currentHp <= 0)
            {
                OnDead();
                return;
            }
            currentHp = ChangeHp(-damage);
        }
    }

    protected virtual int ChangeHp(int value)
    {
        if (currentHp + value > unitData.unitInfo.GetUnitStat().maxHp)
        {
            return unitData.unitInfo.GetUnitStat().maxHp;
        }
        if (currentHp + value < 0)
        {
            return 0;
        }
        return currentHp + value;
    }

    protected virtual void OnDead()
    {
#if UNITY_EDITOR
        Debug.Log("Dead");
#endif
    }

    #endregion

    public bool EqualsUnitType(UnitType unitType)
    {
        return unitType.Equals(unitData.unitInfo.GetUnitType());
    }
}
