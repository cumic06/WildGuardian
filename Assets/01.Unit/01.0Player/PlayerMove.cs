using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private void Start()
    {
        TouchInputManager.Instance.AddTouchingAction(PlayerMoveMent);
    }

    public void Dash()
    {
        if (GestureInputManager.Instance.IsSwipe)
        {
            transform.position += (Vector3)TouchInputManager.Instance.TouchDirection * 5;
            Debug.Log("Dash");
        }
    }

    private void PlayerMoveMent()
    {
        transform.Translate(moveSpeed * Time.deltaTime * TouchInputManager.Instance.TouchOfViewDistance * (Vector3)TouchInputManager.Instance.TouchDirection);
    }
}
