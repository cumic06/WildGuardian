using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonsterAI
{
    //private BossPattern bossPattern;
    public float detectedRange;
    public float patternDelay;

    //public BossAI(BossPattern bossPattern)
    //{
    //    this.bossPattern = bossPattern;
    //}
    protected Coroutine[] patternCor;


    protected override void Start()
    {
        monsterMove.SetMoveSpeed(monster.GetCurrentMoveSpeedStat());
    }

    public virtual void ExcuteBossAI()
    {
        StartCoroutine(BossAIPattern());
    }

    protected virtual IEnumerator BossAIPattern()
    {
        yield return null;
    }

    //public void ExcuteBossAI()
    //{
    //    if (IsCanAttackRange(out Collider2D[] players))
    //    {
    //        if (IsClosePattern())
    //        {
    //            bossPattern.ExcuteClosePattern();
    //        }
    //        else
    //        {
    //            bossPattern.ExcuteFarPattern();
    //        }
    //    }
    //    else
    //    {
    //        monsterMove.FollowPlayer();
    //    }
    //}

    public bool IsClosePattern()
    {
        Collider2D playerCheck = Physics2D.OverlapCircle(transform.position, detectedRange * 0.005f, LayerMaskManager.playerLayer);

        return playerCheck;
    }

    protected override void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectedRange * 0.005f);
    }
}