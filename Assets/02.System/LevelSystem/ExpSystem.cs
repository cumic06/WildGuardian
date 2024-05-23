using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(CircleCollider2D))]
public class ExpSystem : MonoBehaviour
{
    [SerializeField] private float expRange;
    [SerializeField] int expValue;
    private const int playerLayer = 1 << 6;
    private bool isCheck = false;

    private void Start()
    {
        UpdateSystem.Instance.AddFixedUpdateAction(Move);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, expRange);
    }

    private void Move()
    {
        if (isCheck)
        {
            transform.position = Vector2.Lerp(transform.position, Player.Instance.transform.position, Time.deltaTime);
            return;
        }

        if (CheckPlayer())
        {
            isCheck = true;
        }
    }

    private bool CheckPlayer()
    {
        Collider2D[] playerCol = Physics2D.OverlapCircleAll(transform.position, expRange, playerLayer);
        return playerCol.Length > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            LevelSystem.Instance.AddExp(expValue);
            UpdateSystem.Instance.RemoveFixedUpdateAction(Move);
            Destroy(gameObject);
        }
    }
}
