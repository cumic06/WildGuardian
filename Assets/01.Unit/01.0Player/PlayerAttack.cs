using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerAttack : MonoBehaviour, IAttackable
{
    [SerializeField] private int attackPower;
    private const int monsterLayer = 1 << 7;

    private void Start()
    {
        UpdateSystem.Instance.AddUpdateAction(Attack);
    }

    public void SetAttackPower(int value)
    {
        attackPower = value;
    }

    public bool IsCanAttack()
    {
        Collider2D[] checkCircle = Physics2D.OverlapCircleAll(transform.position, Player.Instance.AttackRange, monsterLayer);
        return checkCircle.Length > 0;
    }

    public void Attack()
    {
        if (IsCanAttack() && TouchInputManager.Instance.IsTap)
        {
            Collider2D checkCircle = Physics2D.OverlapCircleAll(transform.position, Player.Instance.AttackRange, monsterLayer).FirstOrDefault();
            if (checkCircle.TryGetComponent(out Monster monster))
            {
                HpManager.Instance.TakeDamage(monster, attackPower);
            }
        }
    }
    protected virtual void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, Player.Instance.AttackRange);
        }
    }
}