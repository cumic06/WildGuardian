using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantTiger : Boss
{
    protected override void Start()
    {
        base.Start();
        SetBossAI(new BossPattern(new IPattern[] { new ScratchPattern(2) }, new IPattern[] { new DashPattern(transform, Player.Instance.transform.position, 10f) }));
    }
}
