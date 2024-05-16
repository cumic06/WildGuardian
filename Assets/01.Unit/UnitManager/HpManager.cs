using UnityEngine;

public class HpManager : MonoSingleton<HpManager>
{
    public void TakeDamage(IDamageable damageUnit, int damage)
    {
        int resultDamage = ChangeHp(-damage, damageUnit.GetCurrentHp(), damageUnit.GetMaxHp());
#if UNITY_EDITOR
        Debug.Log(damageUnit);
#endif
        damageUnit.TakeDamage(resultDamage);
    }

    public void TakeHeal(IHealable healUnit, int heal)
    {
        int resultHeal = ChangeHp(heal, healUnit.GetCurrentHp(), healUnit.GetMaxHp());
        healUnit.TakeHeal(resultHeal);
    }

    private int ChangeHp(int value, int currentHp, int maxHp)
    {
        if (currentHp + value > maxHp)
        {
            return maxHp;
        }
        if (currentHp + value < 0)
        {
            return 0;
        }
        return currentHp + value;
    }
}