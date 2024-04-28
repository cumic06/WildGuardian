using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private void Start()
    {
        InputManager.Instance.OnTouchingAction += () => { transform.Translate(10 * InputManager.Instance.ScaledDragDistance * Time.deltaTime * InputManager.Instance.DragDirection); };
    }

    public void Dash()
    {
        if (InputManager.Instance.IsSwipe)
        {
            transform.position += (Vector3)InputManager.Instance.DragDirection * 10;
            Debug.Log("Dash");
        }
    }
}
