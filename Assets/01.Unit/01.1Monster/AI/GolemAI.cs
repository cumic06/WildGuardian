using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAI : BossAI
{
    public Bullet bullet;

    protected override IEnumerator BossAIPattern()
    {
        WaitForSeconds patternWait = new(patternDelay);

        while (true)
        {
            if (IsClosePattern())
            {
                yield return StartCoroutine(GroundHitPattern());
            }
            else
            {
                yield return StartCoroutine(DashPattern());
                //yield return StartCoroutine(ThrowBulletPattern());
            }
            yield return patternWait;
        }
    }

    private IEnumerator GroundHitPattern()
    {
        GroundHit();
        yield return null;
    }

    private void GroundHit()
    {
        float attackRange = 700;
        int attackDamage = 40;
        Collider2D playerCheck = Physics2D.OverlapCircle(transform.position, attackRange);

        if (playerCheck == null) return;

        playerCheck.TryGetComponent(out Player player);
        HpManager.Instance.TakeDamage(player, attackDamage);
        Debug.Log("GroundHit");
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 700);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 3);
    }

    private IEnumerator DashPattern()
    {
        DashPlayer();
        yield return new WaitForSeconds(1);
    }

    public void DashPlayer()
    {
        float dashSpeed = 400;
        Vector3 dir = (Player.Instance.transform.position - transform.position).normalized;
        transform.position += dashSpeed * Time.deltaTime * dir;

        DashAttack();
        Debug.Log("Dash");
    }

    private void DashAttack()
    {
        int attackDamage = 35;
        Collider2D playerCheck = Physics2D.OverlapCircle(transform.position, 3);

        if (playerCheck != null)
        {
            if (playerCheck.TryGetComponent(out Player player))
            {
                HpManager.Instance.TakeDamage(player, attackDamage);
                Debug.Log("Dash");
            }
        }
    }

    private IEnumerator ThrowBulletPattern()
    {
        ThrowBullet();
        yield return null;
    }

    private void ThrowBullet()
    {
        Debug.Log("Throw");
        Vector2 dir = Player.Instance.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        ObjectPoolSystem.Instance.SpawnObject(bullet.gameObject, transform.position, Quaternion.Euler(0, 0, angle));
    }
}