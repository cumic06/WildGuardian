using UnityEngine;
using System;

public class HpManager : MonoSingleton<HpManager>
{
    public Action<int, int> OnChangeHp;

    public void TakeDamage(IDamageable damageUnit, int damage)
    {
        int resultDamage = damage - damageUnit.GetCurrentDefensePowerStat();
        if (resultDamage <= 0)
        {
            resultDamage = 1;
        }
        damageUnit.TakeDamage(ChangeHp(-resultDamage, damageUnit.GetCurrentHpStat(), damageUnit.GetMaxHpStat()));
    }

    public void TakeHeal(IHealable healUnit, int heal)
    {
        int resultHeal = ChangeHp(heal, healUnit.GetCurrentHpStat(), healUnit.GetMaxHpStat());
        healUnit.TakeHeal(resultHeal);
    }

    private int ChangeHp(int value, int currentHp, int maxHp)
    {
        if (currentHp + value >= maxHp)
        {
            Debug.Log("max");
            return maxHp;
        }
        if (currentHp + value <= 0)
        {
            return 0;
        }
        return currentHp + value;
    }
}