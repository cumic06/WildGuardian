using UnityEngine;

public interface IDamageable : IHpable
{
    public void TakeDamage(int damage);
}

public interface IHealable : IHpable
{
    public void TakeHeal(int heal);
}

public interface IHpable
{
    public void ChangeHp(int value);

    public int GetMaxHpStat();
    public int GetCurrentHpStat();

    public int GetCurrentDefensePowerStat();

    public void OnDead();
}

public interface IAttackable
{
    public void Attack();
}

public interface IMoveable
{
    public void Move();
}