using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Unit : MonoBehaviour, IHpable, IDamageable
{
    #region variable
    [SerializeField] protected UnitData unitData;
    [SerializeField] protected UnitStat unitStat;

    protected Rigidbody2D rigid;
    public Rigidbody2D Rigid => rigid;

    protected SpriteRenderer sprite;

    protected Color originColor;

    private const float speedCorrection = 0.025f;

    private const float hitChangeTime = 0.25f;
    #endregion

    protected virtual void Awake()
    {
        unitStat = unitData.unitInfo.GetUnitStat();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        originColor = sprite.color;
    }

    protected virtual void Start()
    {
        ResetAllStats();
    }

    #region ResetStats
    public void ResetAllStats()
    {
        ResetHp();
    }

    public void ResetHp()
    {
        unitStat.hp = unitStat.maxHp;
    }
    #endregion



    public UnitInfo GetUnitData()
    {
        return unitData.unitInfo;
    }

    #region Hp
    public virtual void TakeDamage(int damage)
    {
        unitStat.hp = damage;
        if (unitStat.hp <= 0)
        {
            OnDead();
        }
    }

    public abstract void ChangeHp(int value);

    protected virtual IEnumerator ChangeColor(Color color)
    {
        WaitForSeconds changeWait = new(hitChangeTime);
        sprite.color = color;
        yield return changeWait;
        sprite.color = originColor;
        yield return changeWait;
    }

    public int GetMaxHpStat()
    {
        return unitStat.maxHp;
    }

    public int GetCurrentHpStat()
    {
        return unitStat.hp;
    }

    public int GetCurrentDefensePowerStat()
    {
        return unitStat.defensePower;
    }

    public float GetCurrentMoveSpeedStat()
    {
        return unitStat.moveSpeed * speedCorrection;
    }

    public abstract void OnDead();
    #endregion

    private Coroutine speedUpCor;
    public void SpeedUp(float parcentValue)
    {
        if (speedUpCor != null)
        {
            StopCoroutine(speedUpCor);
        }
        speedUpCor = StartCoroutine(SpeedUpCor());

        IEnumerator SpeedUpCor()
        {
            unitStat.moveSpeed *= parcentValue;
            yield return new WaitForSeconds(4);
            unitStat.moveSpeed /= parcentValue;
        }
    }
}