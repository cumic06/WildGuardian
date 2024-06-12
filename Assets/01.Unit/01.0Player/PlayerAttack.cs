using UnityEngine;
using System.Linq;

public class PlayerAttack : MonoBehaviour, IAttackable
{
    [SerializeField] private int attackPower;
    [SerializeField] private float attackDelayTime;
    [SerializeField] private float currentAttackDelayTime;
    public Weapon currentWeapon;

    private void Start()
    {
        currentWeapon.SetAttackPower(attackPower);
        UpdateSystem.Instance.AddUpdateAction(Attack);
    }

    public void SetAttackPower(int value)
    {
        attackPower = value;
    }

    public void SetAttackDelayTime(float value)
    {
        attackDelayTime = currentWeapon.ManualAttackTime / value;
    }

    public void Attack()
    {
        currentAttackDelayTime += Time.deltaTime;

        if (TouchInputManager.Instance.IsTap)
        {
            if (currentAttackDelayTime >= attackDelayTime)
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