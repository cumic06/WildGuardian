using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterAI : MonoBehaviour, IAttackable
{
    protected Monster monster;

    protected void Awake()
    {
        monster = GetComponent<Monster>();
    }

    public void AI()
    {
        if (CheckPlayer())
        {
            monster.currentAttackCoolTime += Time.deltaTime;
            if (IsCanAttack())
            {
                monster.currentAttackCoolTime = 0;
                Attack();
                //#if UNITY_EDITOR
                //                Debug.Log("Attack");
                //#endif
            }
        }
        else
        {
            //#if UNITY_EDITOR
            //            Debug.Log("FollowPlayer");
            //#endif
            FollowPlayer();
            monster.currentAttackCoolTime = 0;
        }
    }

    protected void FollowPlayer()
    {
        Vector3 dir = Player.Instance.transform.position - transform.position;
        Vector3 moveVec = monster.CurrentMoveSpeed * dir.normalized;
        transform.Translate(moveVec * Time.deltaTime);
    }

    protected bool CheckPlayer()
    {
        Collider2D[] checkCircle = Physics2D.OverlapCircleAll(transform.position, monster.AttackRange, monster.PlayerLayer);

        return checkCircle.Length > 0;
    }

    protected void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, monster.AttackRange);
        }
    }
    public abstract void Attack();

    public bool IsCanAttack()
    {
        return monster.currentAttackCoolTime >= monster.AttackCoolTime;
    }

}