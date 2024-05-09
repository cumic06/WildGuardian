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
        TouchInputManager.Instance.AddTouchBeganAction(() => { holdUI.transform.position = TouchInputManager.Instance.FirstTouchPoint; });
        TouchInputManager.Instance.AddTouchBeganAction(() => { pointerImage.transform.position = TouchInputManager.Instance.FirstTouchPoint; });
        GestureInputManager.Instance.AddHoldBeganAction(() => { holdUI.SetActive(true); });
        GestureInputManager.Instance.AddHoldEndAction(() => { holdUI.SetActive(false); });
    }

    private void Update()
    {
    }
}
