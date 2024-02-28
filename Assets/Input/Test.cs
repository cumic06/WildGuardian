using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cameraPos = Camera.main.transform.position;
        Vector2 dir = (Vector2)transform.position - cameraPos;
        Camera.main.transform.Translate(dir * Time.deltaTime * 10f);

        if (InputManager.Instance.IsSlide())
        {
            transform.position += (Vector3)InputManager.Instance.TouchDirection*10;
            Debug.Log("Dash");
        }
        else if(InputManager.Instance.IsTouching)
        {
            transform.Translate(InputManager.Instance.TouchDirection * InputManager.Instance.TouchDistance * Time.deltaTime);
        }
    }
}
