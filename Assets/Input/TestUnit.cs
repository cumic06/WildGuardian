using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUnit : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private void Start()
    {
        TouchInputManager.Instance.AddTouchingAction(PlayerMove);
    }

    private void Update()
    {
        Vector2 cameraPos = Camera.main.transform.position;
        Vector2 dir = (Vector2)transform.position - cameraPos;
        Camera.main.transform.Translate(dir * Time.deltaTime * 10f);

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
