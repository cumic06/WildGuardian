using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
public class Player : Unit
{
    public static Player Instance;
    private PlayerMove playerMove;

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
        playerMove = GetComponent<PlayerMove>();
    }

    protected override void Start()
    {
        base.Start();
        UpdateSystem.Instance.AddUpdateAction(playerMove.Dash);
    }

    public override void TakeDamage(UnitType unitType, int damage)
    {
        base.TakeDamage(unitType, damage);
        EffectUI.Instance.FlickrImage(new Color(1, 0, 0, 0.5f));
    }
}