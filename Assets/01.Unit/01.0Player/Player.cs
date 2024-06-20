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
        playerAttack.SetAttackDelayTime(unitStat.attackDelayTime);
    }

    private void OnValidate()
    {
        if (Application.isPlaying)
        {
            playerMove.SetMoveSpeed(GetCurrentMoveSpeedStat());
            playerMove.SetDashPower(playerStat.dashPower);
            playerAttack.SetAttackPower(unitStat.attackPower);
            playerAttack.SetAttackDelayTime(unitStat.attackDelayTime);
        }
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
        Destroy(gameObject);
        GameStateEventBus.Publish(GameState.GameOver);
        Debug.Log("PlayerDead");
    }
    #endregion

    public void UpGradeStat(LevelUpStat levelUpStat, float value)
    {
        switch (levelUpStat)
        {
            case LevelUpStat.HpStat:
                unitData.unitInfo.unitStat.hp *= (int)value;
                Debug.Log(unitData.unitInfo.unitStat.hp * (int)value);
                break;
            case LevelUpStat.ManaStat:
                playerData.playerStat.mana *= (int)value;
                Debug.Log(playerData.playerStat.mana * value);
                break;
            case LevelUpStat.AttackPowerStat:
                unitData.unitInfo.unitStat.attackPower *= (int)value;
                Debug.Log(unitData.unitInfo.unitStat.attackPower * value);
                break;
            case LevelUpStat.AttackCoolTimeStat:
                unitData.unitInfo.unitStat.attackDelayTime /= (int)value;
                Debug.Log(unitData.unitInfo.unitStat.attackDelayTime / value);
                break;
            case LevelUpStat.DefensePowerStat:
                unitData.unitInfo.unitStat.defensePower *= (int)value;
                Debug.Log(unitData.unitInfo.unitStat.defensePower * value);
                break;
            case LevelUpStat.HealHpStat:
                break;
            case LevelUpStat.HealManaStat:
                break;
        }
    }

    private void OnDestroy()
    {
        UpdateSystem.Instance.RemoveUpdateAction(playerMove.Dash);
    }
}