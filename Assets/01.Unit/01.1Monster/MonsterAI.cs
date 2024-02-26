using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    [SerializeField] protected LayerMask wallLayer;
    protected Monster monster;
    protected Collider2D boxCollider2D;

    private void Awake()
    {
        monster = GetComponent<Monster>();
        boxCollider2D = GetComponent<Collider2D>();
    }

    private void Start()
    {
        StartCoroutine(nameof(FollowPlayer));
    }

    private IEnumerator FollowPlayer()
    {
        Vector2 followDirection = Vector2.zero;
        Vector2 closePos;
        while (Vector3.Distance(Player.Instance.transform.position, transform.position) > monster.CurrentAttackRange)
        {
            if (!IsCheckWall(out Wall afs))
            {
                followDirection = (Player.Instance.transform.position - transform.position).normalized;
                Debug.Log("Follow");
                yield return null;
            }
            else if (IsCheckWall(out Wall wall))
            {
                closePos = GetCloseDis(wall);
                Debug.Log(closePos);
                followDirection = ((Vector3)closePos - transform.position).normalized;
                Debug.Log("CheckWall");
                yield return null;
            }
            transform.Translate(monster.CurrentMoveSpeed * Time.deltaTime * followDirection);
            yield return null;
        }
        Debug.Log("Attack");
    }

    private static Vector2 GetCloseDis(Wall wall)
    {
        float closeDis = Vector2.Distance(Player.Instance.transform.position, wall.Edges[0].position);
        Vector2 closePos = wall.Edges[0].position;

        for (int i = 0; i < wall.Edges.Length; i++)
        {
            float distance = Vector2.Distance(Player.Instance.transform.position, wall.Edges[i].position);
            if (distance < closeDis)
            {
                closeDis = distance;
                closePos = wall.Edges[i].position;
            }
        }
        return closePos;
    }

    private bool IsCheckWall(out Wall wall)
    {
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, transform.right, 1, wallLayer);
        wall = null;

        if (rayHit)
        {
            if (rayHit.collider.TryGetComponent(out Wall tryWall))
            {
                wall = tryWall;
                Debug.Log("Wall");
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (Application.isPlaying)
        {
            Gizmos.DrawWireCube(transform.position, monster.CurrentAttackRange * Vector2.one);

        }
        Gizmos.DrawRay(transform.position, transform.right);
    }
}
