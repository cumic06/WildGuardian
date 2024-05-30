using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Unit : MonoBehaviour, IHpable, IDamageable
{
    #region variable
    [SerializeField] protected UnitData unitData;

    protected Rigidbody2D rigid;
    public Rigidbody2D Rigid => rigid;

    protected SpriteRenderer sprite;

    protected Color originColor;
    #endregion

    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        originColor = sprite.color;
    }

    protected virtual void Start()
    {

    }

    public UnitInfo GetUnitData()
    {
        return unitData.unitInfo;
    }

    #region Hp
    public virtual void TakeDamage(int damage)
    {
        unitData.unitInfo.GetUnitStat().hp = damage;
        if (unitData.unitInfo.GetUnitStat().hp <= 0)
        {
            OnDead();
        }
    }

    public abstract void ChangeHp(int value);

    protected virtual IEnumerator ChangeColor(Color color)
    {
        WaitForSeconds changeWait = new(1f);
        sprite.color = color;
        yield return changeWait;
        sprite.color = originColor;
    }

    public int GetMaxHp()
    {
        return unitData.unitInfo.GetUnitStat().maxHp;
    }

    public int GetCurrentHp()
    {
        return unitData.unitInfo.GetUnitStat().hp;
    }

    public int GetCurrentDefensePower()
    {
        return unitData.unitInfo.GetUnitStat().defensePower;
    }

    public float GetCurrentMoveSpeed()
    {
        return unitData.unitInfo.GetUnitStat().moveSpeed;
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
            unitData.unitInfo.GetUnitStat().moveSpeed *= parcentValue;
            yield return new WaitForSeconds(4);
            unitData.unitInfo.GetUnitStat().moveSpeed /= parcentValue;
        }
    }
}
