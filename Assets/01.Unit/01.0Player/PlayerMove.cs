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
        Vector3 moveVec = moveSpeed * Time.deltaTime * TouchInputManager.Instance.TouchOfViewDistance * (Vector3)TouchInputManager.Instance.TouchDirection;
        Debug.Log(moveVec);

        if (moveVec.x <= 0.01f || moveVec.y <= 0.01f)
        {
            animator.SetAnimation(AnimationType.Move, false);
            return;
        }
        animator.SetAnimation(AnimationType.Move, true);
        transform.Translate(moveVec);
    }

    private void OnDestroy()
    {
        TouchInputManager.Instance.RemoveTouchingAction(Move);
        UpdateSystem.Instance.RemoveFixedUpdateAction(Flip);
    }
}