using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    protected Collider2D boxCollider2D;

    private void Awake()
    {
        boxCollider2D = GetComponent<Collider2D>();
    }

    public void Move()
    {
        Debug.Log("Move");
    }
}