using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    private float moveSpeed;
    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    public void FollowPlayer()
    {
        if (Player.Instance == null) return;
        Vector3 dir = Player.Instance.transform.position - transform.position;
        Vector3 moveVec = moveSpeed * dir.normalized;
        transform.Translate(moveVec * Time.deltaTime);
    }
}
