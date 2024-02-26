using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    [SerializeField] private LayerMask wallLayer;
    private Monster monster;
    private CapsuleCollider2D capsuleCollider2D;

    private void Awake()
    {
        monster = GetComponent<Monster>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector2 followDirection = Player.Instance.transform.position - transform.position;
        followDirection.Normalize();
        transform.Translate(monster.CurrentMoveSpeed * Time.deltaTime * followDirection);

        if (IsCheckWall(out Vector2 vertex))
        {

        }
    }
    private bool IsCheckWall(out Vector2 vertex)
    {
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, transform.right, 1, wallLayer);
        vertex = Vector2.zero;

        if (rayHit)
        {
            if (rayHit.collider.CompareTag("Wall"))
            {
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
        Gizmos.DrawRay(transform.position, transform.right);
    }
}
