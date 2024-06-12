using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : Weapon
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform bulletPos;

    public override void Attack()
    {
        Debug.Log("Wand");
    }

    public override void SkillAttack()
    {
        Debug.Log("WandSkill");
    }
}
