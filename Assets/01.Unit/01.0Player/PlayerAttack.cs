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
                animator.SetAnimation(AnimationType.Attack, true);
                currentAttackDelayTime = 0;
            }
            animator.SetAnimation(AnimationType.Attack, false);
        }
    }

    private void OnDestroy()
    {
        UpdateSystem.Instance.RemoveUpdateAction(Attack);
    }
}