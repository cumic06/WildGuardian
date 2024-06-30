using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonsterAI
{
    private BossPattern bossPattern;
    private float detectedRange;

    public BossAI(BossPattern bossPattern)
    {
        this.bossPattern = bossPattern;
    }

    public void ExcuteBossAI()
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

    public bool IsClosePattern()
    {
        return detectedRange <= (Player.Instance.transform.position - transform.position).sqrMagnitude;
    }
}