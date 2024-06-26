using UnityEngine;
using System.Linq;

public class PlayerAttack : UnitAttack, IAttackable
{
    public Weapon currentWeapon;

    private void Start()
    {
        currentWeapon.SetAttackPower(attackPower);
        currentWeapon.SetAttackRange(attackRange);
    }

    public override void Attack()
    {
        currentAttackDelayTime += Time.deltaTime;
        if (TouchInputManager.Instance.IsTap)
        {
            if (IsCanAttack())
            {
                currentWeapon.Attack();
                currentAttackDelayTime = 0;
            }
        }
    }

    private void OnDestroy()
    {
        UpdateSystem.Instance.RemoveUpdateAction(Attack);
    }
}