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

    [SerializeField] private int exp;
    #endregion

    protected override void Awake()
    {
        base.Awake();
        monsterAI = GetComponent<MonsterAI>();
    }

    protected override void Start()
    {
        base.Start();
        UpdateSystem.Instance.AddFixedUpdateAction(monsterAI.AI);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        StartCoroutine(ChangeColor(Color.white));
        StartCoroutine(ChangeSize());
    }

    IEnumerator ChangeSize()
    {
        WaitForSeconds changeWait = new(0.25f);
        transform.localScale = new Vector2(1.15f, 1.15f);
        yield return changeWait;
        transform.localScale = new Vector2(1, 1);
    }

    public override void ChangeHp(int value)
    {

    }

    public override void OnDead()
    {
#if UNITY_EDITOR
        Debug.Log("MonsterDead");
#endif
        UpdateSystem.Instance.RemoveFixedUpdateAction(monsterAI.AI);

        //int randomExp = Random.Range(0, 3);
        //if (randomExp == 3)
        //{
        int randomType = Random.Range(0, 3);
        Debug.Log(randomType);
        LevelSystem.Instance.SpawnExp(transform.position, (ExpType)randomType);
        //}

        Destroy(gameObject);
    }
}