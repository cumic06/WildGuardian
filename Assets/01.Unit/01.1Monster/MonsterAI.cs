using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    protected Collider2D boxCollider2D;

    private void Awake()
    {
        boxCollider2D = GetComponent<Collider2D>();
    }

    public void AI()
    {

    }

    public bool Move()
    {
        Debug.Log("Move");
        return true;
    }
}