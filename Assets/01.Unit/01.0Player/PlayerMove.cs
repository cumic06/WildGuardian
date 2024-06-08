using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour, IMoveable
{
    private float dashPower;
    private float moveSpeed;

    private void Start()
    {
        TouchInputManager.Instance.AddTouchingAction(Move);
    }

    public void SetMoveSpeed(float value)
    {
        moveSpeed = value;
    }

    public void SetDashPower(float value)
    {
        dashPower = value;
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
        transform.Translate(moveSpeed * Time.deltaTime * TouchInputManager.Instance.TouchOfViewDistance * (Vector3)TouchInputManager.Instance.TouchDirection);
    }
}
