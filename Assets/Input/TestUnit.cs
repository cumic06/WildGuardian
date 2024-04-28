using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUnit : MonoBehaviour
{
    private void Start()
    {
        InputManager.Instance.OnTouchingAction += () => { transform.Translate(InputManager.Instance.ScaledDragDistance * Time.deltaTime * InputManager.Instance.DragDirection * 10); };
    }

    private void Update()
    {
        Vector2 cameraPos = Camera.main.transform.position;
        Vector2 dir = (Vector2)transform.position - cameraPos;
        Camera.main.transform.Translate(dir * Time.deltaTime * 10f);

        if (InputManager.Instance.IsSwipe)
        {
            transform.position += (Vector3)InputManager.Instance.DragDirection * 10;
            Debug.Log("Dash");
        }
    }
}
