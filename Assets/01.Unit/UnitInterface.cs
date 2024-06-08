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

    public int GetMaxHp();
    public int GetCurrentHp();

    public int GetCurrentDefensePower();

    public void OnDead();
}

public interface IAttackable
{
    public bool IsCanAttackRange(out Collider2D[] attackUnit);
    public void Attack();
}

public interface IMoveable
{
    public void Move();
}