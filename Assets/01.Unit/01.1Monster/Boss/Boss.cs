using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Monster
{
    protected BossAI bossAI;

    protected override void Awake()
    {
        base.Awake();
        bossAI = GetComponent<BossAI>();
    }

    protected override void Start()
    {
        UpdateSystem.Instance.AddFixedUpdateAction(bossAI.ExcuteBossAI);
    }

    protected void SetBossAI(BossPattern bossPattern)
    {
        bossAI = new BossAI(bossPattern);
    }

    public override void OnDead()
    {
        base.OnDead();
        UpdateSystem.Instance.RemoveFixedUpdateAction(bossAI.ExcuteBossAI);
    }
}