
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

    public void OnDead();
}

public interface IAttackable
{
    public bool IsCanAttack();
    public void Attack();
}

public interface IMoveable
{
    public void Move();
}