using UnityEngine;
using System.Linq;

public class PlayerAttack : MonoBehaviour, IAttackable
{
    [SerializeField] private int attackPower;
    [SerializeField] private WeaponType weaponType;
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform bulletPos;

    private const int monsterLayer = 1 << 7;

    private void Start()
    {
        TouchInputManager.Instance.AddTouchBeganAction(Attack);
    }

    public void SetAttackPower(int value)
    {
        attackPower = value;
    }

    public bool IsCanAttack()
    {
        Collider2D[] checkCircle = Physics2D.OverlapCircleAll(transform.position, Player.Instance.AttackRange, monsterLayer);
        return checkCircle.Length > 0;
    }

    public void Attack()
    {
        if (IsCanAttack())
        {
            switch (weaponType)
            {
                case WeaponType.MeleeEquipment:
                    Collider2D checkCircle = Physics2D.OverlapCircleAll(transform.position, Player.Instance.AttackRange, monsterLayer).FirstOrDefault();
                    if (checkCircle.TryGetComponent(out Monster monster))
                    {
                        HpManager.Instance.TakeDamage(monster, attackPower);
                    }
                    break;

                case WeaponType.RangedEquipment:
                    GameObject spawnBullet = Instantiate(bullet.gameObject);
                    spawnBullet.GetComponent<Bullet>().SetAttackPower(attackPower);

                    if (bulletPos != null)
                    {
                        //#if UNITY_EDITOR
                        //                Debug.Log("BulletPos");
                        //#endif
                        spawnBullet.transform.position = bulletPos.position;
                    }
                    spawnBullet.transform.position = transform.position;
                    //#if UNITY_EDITOR
                    //            Debug.Log("BulletPosNull");
                    //#endif
                    break;
            }
        }
    }
    protected virtual void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, Player.Instance.AttackRange);
        }
    }
}