using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private UnitType bulletType;
    [SerializeField] private float bulletSpeed;
    private int bulletDamage;

    private void Start()
    {
        transform.LookAt2D(Player.Instance.transform.position);
        UpdateSystem.Instance.AddFixedUpdateAction(Move);
    }

    public void SetAttackPower(int bulletDamage)
    {
        Debug.Log(bulletDamage);
        this.bulletDamage = bulletDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Unit unit))
        {
            unit.TakeDamage(bulletType, bulletDamage);

            if (bulletType != unit.GetUnitType())
            {
                UpdateSystem.Instance.RemoveFixedUpdateAction(Move);
                Destroy(gameObject);
            }
        }
    }

    protected virtual void Move()
    {
        transform.Translate(Vector2.right * Time.deltaTime);
    }
}
