using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    protected Monster monster;
    protected Collider2D boxCollider2D;

    private void Awake()
    {
        monster = GetComponent<Monster>();
        boxCollider2D = GetComponent<Collider2D>();
    }

    private void Start()
    {
        UpdateSystem.Instance.AddFixedUpdateAction(Move);
        //StartCoroutine(nameof(FollowPlayer));
    }

    private void Move()
    {
        Debug.Log("HI");
    }
}
