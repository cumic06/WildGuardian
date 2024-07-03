using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Boss
{
    public GameObject bullet;

    protected override void Start()
    {
        base.Start();
        //SetBossAI(new BossPattern(new IPattern[] { new GroundHitPattern(transform, 700, 40, 1.5f) }, new IPattern[] { new DashPattern(transform, Player.Instance.transform.position, 400, 35, 1.5f), new ThrowBulletPattern(30, bullet, transform, 1.5f) }));
    }
}
