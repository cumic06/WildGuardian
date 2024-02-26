using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MonsterAI))]
public class Monster : Unit
{
    #region variable
    [SerializeField] protected int damage;
    public Rigidbody2D Rigid => rigid;

    protected SpriteRenderer spriteRenderer;
    public SpriteRenderer SpriteRenderer => spriteRenderer;

    protected MonsterAI monsterAI;
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

    protected override void OnDead()
    {
        base.OnDead();
        UpdateSystem.Instance.RemoveFixedUpdateAction(() => monsterAI.AI());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Unit unit))
        {
            unit.TakeDamage(unitData.unitInfo.GetUnitType(), damage);
        }
    }
}

[CreateAssetMenu(fileName = "UnitData_MonsterData", menuName = "Data/UnitData/MonsterData")]
public class MonsterData : UnitData
{

}