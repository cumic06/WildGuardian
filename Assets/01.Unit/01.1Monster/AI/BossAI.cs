using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonsterAI
{
    #region veriable
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform bulletPos;

    private readonly Coroutine[] patternCor = new Coroutine[4];

    public BossPatternData bossPatternData;
    #endregion

    public override void Attack()
    {

    }
}