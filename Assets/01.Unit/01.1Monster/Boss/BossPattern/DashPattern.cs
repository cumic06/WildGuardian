using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPattern : IPattern
{
    private Transform bossTransform;
    private Vector3 playerPos;
    private float dashSpeed;

    public DashPattern(Transform bossTransform, Vector3 playerPos, float dashSpeed)
    {
        this.bossTransform = bossTransform;
        this.playerPos = playerPos;
        this.dashSpeed = dashSpeed;
    }

    public void ExcutePattern()
    {
        DashPlayer();
    }

    public void DashPlayer()
    {
        Vector3 dir = (playerPos - bossTransform.position).normalized;
        bossTransform.position += dashSpeed * Time.deltaTime * dir;
        Debug.Log("Dash");
    }
}