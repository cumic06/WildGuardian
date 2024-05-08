using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private void Start()
    {
        TouchInputManager.Instance.AddTouchingAction(PlayerMove);
    }

    public void Dash()
    {
        if (GestureInputManager.Instance.IsSwipe)
        {
            transform.position += (Vector3)TouchInputManager.Instance.TouchDirection * 5;
            Debug.Log("Dash");
        }
    }

    private void PlayerMove()
    {
        transform.Translate((Vector3)TouchInputManager.Instance.TouchDirection * Time.deltaTime * TouchInputManager.Instance.TouchOfViewDistance * moveSpeed);
    }
}
