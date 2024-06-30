using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour, IMoveable
{
    private float dashPower;
    private float moveSpeed;
    private IAnimatorCommand animator;

    private void Awake()
    {
        animator = GetComponent<PlayerAnimationController>();
    }

    private void Start()
    {
        TouchInputManager.Instance.AddTouchingAction(Move);
        UpdateSystem.Instance.AddFixedUpdateAction(Flip);
        UpdateSystem.Instance.AddFixedUpdateAction(MoveAnimation);
    }

    public void SetMoveSpeed(float value)
    {
        moveSpeed = value;
    }

    public void SetDashPower(float value)
    {
        dashPower = value;
    }

    private void Flip()
    {
        transform.localScale = TouchInputManager.Instance.TouchDirection.x >= 0 ? Player.Instance.StartSize : new Vector3(-Player.Instance.StartSize.x, Player.Instance.StartSize.y, Player.Instance.StartSize.z);
    }

    public void Dash()
    {
        if (GestureInputManager.Instance.IsSwipe)
        {
            transform.position += (Vector3)TouchInputManager.Instance.TouchDirection * dashPower;
            //#if UNITY_EDITOR
            //            Debug.Log("Dash");
            //#endif
        }
    }

    public void Move()
    {
        if (IsCanMove())
        {
            transform.Translate(GetMoveVec());
            return;
        }
    }
    private Vector3 GetMoveVec()
    {
        Vector3 moveVec = moveSpeed * Time.deltaTime * TouchInputManager.Instance.TouchOfViewDistance * (Vector3)TouchInputManager.Instance.TouchDirection;
        return moveVec;
    }

    private void MoveAnimation()
    {
        if (!IsCanMove())
        {
            animator.SetAnimation(AnimationType.Move, false);
        }
        else
        {
            animator.SetAnimation(AnimationType.Move, true);
        }

    }
    private bool IsCanMove()
    {
        //움직이다 뗐을 때 IsCanMoveTrue버그
        Debug.Log($"0.01f { Mathf.Abs(GetMoveVec().x) <= 0.01f && Mathf.Abs(GetMoveVec().y) <= 0.01f}");
        Debug.Log($"!=0{ GetMoveVec().x != 0 || GetMoveVec().y != 0}");
        bool isCanMove = Mathf.Abs(GetMoveVec().x) <= 0.01f && Mathf.Abs(GetMoveVec().y) <= 0.01f && GetMoveVec().x != 0 || GetMoveVec().y != 0;
        Debug.Log($"isCanMove{isCanMove}");
        return isCanMove;
    }

    private void OnDestroy()
    {
        TouchInputManager.Instance.RemoveTouchingAction(Move);
        UpdateSystem.Instance.RemoveFixedUpdateAction(Flip);
        UpdateSystem.Instance.RemoveFixedUpdateAction(MoveAnimation);
    }
}