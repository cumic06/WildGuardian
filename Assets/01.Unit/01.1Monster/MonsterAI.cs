using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask playerLayer;

    protected Collider2D boxCollider2D;

    private Monster monster;
    [SerializeField] private float currentAttackCoolTime;

    private void Awake()
    {
        monster = GetComponent<Monster>();
        boxCollider2D = GetComponent<Collider2D>();
    }

    public void AI()
    {
        if (CheckPlayer())
        {
            Attack();
        }
        else
        {
            FollowPlayer();
        }
    }

    public void FollowPlayer()
    {
        Vector3 dir = Player.Instance.transform.position - transform.position;
        Vector3 moveVec = monster.CurrentMoveSpeed * Time.deltaTime * dir;
        transform.Translate(moveVec);
    }

    public bool CheckPlayer()
    {
        Collider2D[] checkCircle = Physics2D.OverlapCircleAll(transform.position, attackRange, playerLayer);

        return checkCircle.Length > 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public void Attack()
    {
        currentAttackCoolTime += Time.deltaTime;

        if (currentAttackCoolTime >= monster.AttackCoolTime)
        {
            Debug.Log("Attack");
            currentAttackCoolTime = 0;
        }
    }
}