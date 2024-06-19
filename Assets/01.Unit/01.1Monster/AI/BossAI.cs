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
    public BossPatternData bossPatternData;
    #endregion

    public override void Attack()
    {
        int randomPattern = Random.Range(0, patternCor.Length);

        if (patternCor[randomPattern] != null)
        {
            StopCoroutine(patternCor[randomPattern]);
        }
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, buffRange);
    }
}