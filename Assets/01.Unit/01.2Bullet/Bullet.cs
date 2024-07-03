using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected int bulletDamage;

    protected void Start()
    {
        UpdateSystem.Instance.AddFixedUpdateAction(Move);
    }

    public void SetAttackPower(int bulletDamage)
    {
        this.bulletDamage = bulletDamage;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable unit))
        {
            HpManager.Instance.TakeDamage(unit, bulletDamage);
            Destroy(gameObject);
        }
    }

    protected virtual void Move()
    {
        Vector2 moveVec = bulletSpeed * Time.deltaTime * Vector2.right;
        transform.Translate(moveVec);
    }

    protected void OnDestroy()
    {
        UpdateSystem.Instance.RemoveFixedUpdateAction(Move);
    }
}
