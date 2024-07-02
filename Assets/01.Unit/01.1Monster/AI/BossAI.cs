using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonsterAI
{
    private BossPattern bossPattern;
    public float detectedRange;

    public BossAI(BossPattern bossPattern)
    {
        this.bossPattern = bossPattern;
    }

    protected override void Start()
    {
        monsterMove.SetMoveSpeed(monster.GetCurrentMoveSpeedStat());
    }

    public void ExcuteBossAI()
    {
        if (IsCanAttackRange(out Collider2D[] players))
        {
            if (IsClosePattern())
            {
                bossPattern.ExcuteClosePattern();
            }
            else
            {
                bossPattern.ExcuteFarPattern();
            }
        }
        else
        {
            monsterMove.FollowPlayer();
        }
    }

    public bool IsClosePattern()
    {
        return detectedRange <= (Player.Instance.transform.position - transform.position).sqrMagnitude;
    }
}