using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    [SerializeField] protected LayerMask wallLayer;
    protected Monster monster;
    protected Collider2D boxCollider2D;
    protected Vector2 followDirection;

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
        yield return null;
    }

    private Vector2 GetCloseDis(Wall wall)
    {
        Vector2 closePos = Vector2.zero;

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
                Debug.Log(wall.name);
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
