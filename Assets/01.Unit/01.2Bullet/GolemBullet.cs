using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemBullet : Bullet
{
    public Bullet smallBullet;

    private Vector2[] spawnVec = new Vector2[4] { 5 * (Vector2.up + Vector2.left), 5 * (Vector2.up * Vector2.right), 5 * (Vector2.down + Vector2.left), 5 * (Vector2.down * Vector2.right) };

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable unit))
        {
            HpManager.Instance.TakeDamage(unit, bulletDamage);
            for (int i = 0; i < 4; i++)
            {
                Instantiate(smallBullet, transform.position + (Vector3)spawnVec[i], Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}