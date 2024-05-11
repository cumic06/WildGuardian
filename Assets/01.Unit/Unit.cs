using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Unit : MonoBehaviour, IHpable, IDamageable
{
    #region variable
    [SerializeField] protected UnitData unitData;

    [SerializeField] protected int currentHp = 0;
    public int CurrentHp => currentHp;

    [SerializeField] protected float currentMoveSpeed = 0;
    public float CurrentMoveSpeed => currentMoveSpeed;

    [SerializeField] protected float currentDefensePower = 0;
    public float CurrentDefensePower => currentDefensePower;

    [SerializeField] protected float currentAttackPower = 0;
    public float CurrentAttackPower => currentAttackPower;

    [SerializeField] protected float attackCoolTime = 0;
    public float AttackCoolTime => attackCoolTime;

    protected Rigidbody2D rigid;
    public Rigidbody2D Rigid => rigid;

    protected SpriteRenderer sprite;
    #endregion

    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        ResetAll();
    }

    protected virtual void Start()
    {

    }

    #region Reset
    protected void ResetAll()
    {
        ResetHp();
        ResetMoveSpeed();
        ResetDefesePower();
        ResetAttackPower();
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
    protected void ResetAttackPower()
    {
        currentAttackPower = unitData.unitInfo.GetUnitStat().attackPower;
    }
    #endregion

    public UnitInfo GetUnitData()
    {
        return unitData.unitInfo;
    }

    public UnitType GetUnitType()
    {
        return unitData.unitInfo.GetUnitType();
    }

    public bool EqualsUnitType(UnitType unitType)
    {
        return unitType.Equals(unitData.unitInfo.GetUnitType());
    }

    #region Hp
    public virtual void TakeDamage(int damage)
    {
        currentHp = damage;

        if (currentHp < 0)
        {
            OnDead();
        }
    }

    public abstract void ChangeHp(int value);

    public int GetMaxHp()
    {
        return unitData.unitInfo.GetUnitStat().maxHp;
    }

    public int GetCurrentHp()
    {
        return currentHp;
    }

    public abstract void OnDead();
    #endregion
}
