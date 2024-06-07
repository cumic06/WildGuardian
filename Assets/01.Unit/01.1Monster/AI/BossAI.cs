using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonsterAI
{
    #region veriable
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform bulletPos;

    private readonly Coroutine[] patternCor = new Coroutine[4];

    [SerializeField] private float buffRange;
    [SerializeField] private GameObject buffImage;

    [SerializeField] private LayerMask monsterLayer;
    #endregion

    public override void Attack()
    {
        int randomPattern = Random.Range(0, patternCor.Length);

        if (patternCor[randomPattern] != null)
        {
            StopCoroutine(patternCor[randomPattern]);
        }

        //switch (randomPattern)
        //{
        //    case 0:
        //        patternCor[0] = StartCoroutine(NormalMeleeAttack());
        //        buffImage.SetActive(false);
        //        Debug.Log("NormalMeleeAttack");
        //        break;
        //    case 1:
        //        patternCor[1] = StartCoroutine(NormalFarAttack());
        //        buffImage.SetActive(false);
        //        Debug.Log("NormalFarAttack");
        //        break;
        //    case 2:
        //        patternCor[2] = StartCoroutine(SpawnMonster());
        //        buffImage.SetActive(false);
        //        Debug.Log("SpawnMonster");
        //        break;
        //    case 3:
        //        patternCor[3] = StartCoroutine(Buff());
        //        Debug.Log("Buff");
        //        break;
        //}
    }

    //private IEnumerator NormalMeleeAttack()
    //{
    //    Collider2D[] checkCircle = Physics2D.OverlapCircleAll(transform.position, monster.AttackRange, monster.PlayerLayer);
    //    if (checkCircle.Length > 0)
    //    {
    //        foreach (var check in checkCircle)
    //        {
    //            if (check.TryGetComponent(out IDamageable player))
    //            {
    //                HpManager.Instance.TakeDamage(player, monster.GetUnitData().GetUnitStat().attackPower);
    //            }
    //        }
    //    }
    //    yield return null;
    //}

    //private IEnumerator NormalFarAttack()
    //{
    //    Collider2D[] playerCheckCircle = Physics2D.OverlapCircleAll(transform.position, monster.AttackRange, monster.PlayerLayer);
    //    if (playerCheckCircle.Length > 0)
    //    {
    //        GameObject spawnBullet = Instantiate(bullet.gameObject);
    //        spawnBullet.GetComponent<Bullet>().SetAttackPower(monster.GetUnitData().GetUnitStat().attackPower);

    //        if (bulletPos != null)
    //        {
    //            //#if UNITY_EDITOR
    //            //                Debug.Log("BulletPos");
    //            //#endif
    //            spawnBullet.transform.position = bulletPos.position;
    //        }
    //        spawnBullet.transform.position = transform.position;
    //        //#if UNITY_EDITOR
    //        //            Debug.Log("BulletPosNull");
    //        //#endif
    //    }
    //    yield return null;
    //}

    //private IEnumerator SpawnMonster()
    //{
    //    Vector2 randomSpawnRange = (Vector2)transform.position + Random.insideUnitCircle * 1.5f;
    //    SpawnMonsterSystem.Instance.SpawnMonster(randomSpawnRange);
    //    yield return null;
    //}

    //private IEnumerator Buff()
    //{
    //    buffImage.SetActive(true);
    //    yield return null;
    //}

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, buffRange);
    }
}