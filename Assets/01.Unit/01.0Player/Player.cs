using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMove), typeof(PlayerAttack))]
public class Player : Unit
{
    #region veriable
    private const float levelUpValue = 1.4f;
    public static Player Instance;
    private PlayerMove playerMove;
    private PlayerAttack playerAttack;
    [SerializeField] private float maxExp;
    [SerializeField] private float currentExp;
    [SerializeField] private int level;
    private float mana;
    private float coolTimeReduce;

    public float AttackRange => GetUnitData().GetUnitStat().attackRange;
    #endregion

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
        playerMove = GetComponent<PlayerMove>();
        playerAttack = GetComponent<PlayerAttack>();
        playerMove.SetMoveSpeed(currentMoveSpeed);
        playerAttack.SetAttackPower(currentAttackPower);
    }

    protected override void Start()
    {
        base.Start();
        UpdateSystem.Instance.AddUpdateAction(playerMove.Dash);
    }

    #region Hp
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        EffectUI.Instance.FlickrImage(new Color(1, 0, 0, 0.5f));
    }

    public override void ChangeHp(int value)
    {

    }

    public override void OnDead()
    {
        Debug.Log("PlayerDead");
    }
    #endregion

    [ContextMenu("100Exp")]
    private void HunExp()
    {
        AddExp(500);
    }

    public void AddExp(int value)
    {
        currentExp += value;

        int levelUpCount = (int)(currentExp / maxExp);
        for (int i = 0; i < levelUpCount; i++)
        {
            if (currentExp >= maxExp)
            {
                currentExp -= maxExp;
                LevelUp(1);
            }
        }
    }

    private void LevelUp(int value)
    {
        level += value;
        maxExp *= levelUpValue;
    }
}