using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUI : MonoBehaviour
{
    [SerializeField] private Image pointerImage;

    [SerializeField] private GameObject holdUI;

    [SerializeField] private Image[] skills;

    private Vector2[] directions = new Vector2[4] { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

    private void Start()
    {
        InputManager.Instance.OnTouchDownAction += () => { holdUI.transform.position = InputManager.Instance.GetTouchPoint(); };
        InputManager.Instance.OnTouchDownAction += () => { pointerImage.transform.position = InputManager.Instance.GetTouchPoint(); };
    }

    private void Update()
    {
        if (InputManager.Instance.IsTouching)
        {
            if (InputManager.Instance.IsHolding)
            {
                holdUI.SetActive(true);
            }
        }
        else
        {
            holdUI.SetActive(false);
        }
    }
}
