using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMove), typeof(PlayerAttack))]
public class Player : Unit
{
    #region veriable
    public static Player Instance;
    private PlayerMove playerMove;
    private PlayerAttack playerAttack;
    [Space]
    public PlayerData playerData;
    public PlayerStat playerStat;

    public float AttackRange => GetUnitData().GetUnitStat().attackRange;
    #endregion

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
        playerMove = GetComponent<PlayerMove>();
        playerAttack = GetComponent<PlayerAttack>();
        playerStat = playerData.playerStat;
    }

    protected override void Start()
    {
        base.Start();
        UpdateSystem.Instance.AddUpdateAction(playerMove.Dash);
        playerMove.SetMoveSpeed(GetCurrentMoveSpeedStat());
        playerMove.SetDashPower(playerStat.dashPower);
        playerAttack.SetAttackPower(unitStat.attackPower);
    }

    #region Hp
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        EffectUI.Instance.FlickrImage(new Color(1, 0, 0, 0.5f));
        HpManager.Instance.OnChangeHp?.Invoke(GetCurrentHpStat(), GetMaxHpStat());
    }

    public override void ChangeHp(int value)
    {

    }

    public override void OnDead()
    {
        Debug.Log("PlayerDead");
    }
    #endregion
}