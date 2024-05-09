interface IDamageable
{
    public void TakeDamage(UnitType unitType, int damage);
}

interface IHealable
{
    public void TakeHeal(int heal);
}

interface IHpable
{
    public void ChangeHp(int value);
}

interface IAttackable
{
    public bool IsCanAttack();
    public void Attack();
}

interface IMoveable
{
    public void Move();
}