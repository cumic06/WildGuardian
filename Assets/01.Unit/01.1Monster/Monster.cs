using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Unit
{
    [SerializeField] protected int damage;
    protected Rigidbody2D rigid;
    public Rigidbody2D Rigid => rigid;

    protected SpriteRenderer spriteRenderer;
    public SpriteRenderer SpriteRenderer => spriteRenderer;

    protected override void Awake()
    {
        base.Awake();
        rigid = GetComponent<Rigidbody2D>();
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
